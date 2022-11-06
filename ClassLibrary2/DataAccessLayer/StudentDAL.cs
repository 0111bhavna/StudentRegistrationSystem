using ClassLibrary2.DataAccessLayer;
using RepositoryLibrary.HelperFunctions;
using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace RepositoryLibrary.DataAccessLayer
{
    public class StudentDAL : IStudentDAL
    {
        private const string CreateStudentQuery = @"Insert into Student ([StudentId], [NationalId],[FirstName],[Surname],[PhoneNumber],[DateOfBirth],[GuardianName])
                                                    values (@StudentId,@NationalId, @FirstName,@Surname,@PhoneNumber, @DateOfBirth, @GuardianName) ";
        private const string GetStudentsQuery = @"Select [FirstName], [Surname], [NationalId],[PhoneNumber], [DateOfBirth], [GuardianName]from Student";
        private const string resultQuery = @"INSERT INTO Results ([SubjectId],[GradeId],[StudentId]) VALUES (@SubjectId,@GradeId,@StudentId)";
        private const string GetAllStudentsWithResults = @"select S.Status, S.StudentId, FirstName, Surname, Sub.SubjectId, G.GradeId, SubjectName, GradeName, GradeScore, ResultId from Student as S
                                                        inner join Results R on S.StudentId=R.StudentId
                                                        inner join Grade G on R.GradeId=G.GradeId
                                                        inner join Subject Sub on R.SubjectId=Sub.SubjectId";
        private const string GetNationalIdQuery = @"select NationalId from Student where NationalId = @NationalId";
        private const string GetPhoneNumberQuery = @"select PhoneNumber from Student where PhoneNumber=@PhoneNumber";
        private readonly IDatabaseHelper DatabaseHelper;
        private readonly IUserDAL UserDAL;
        private readonly IAddressDAL AddressDAL;
        public StudentDAL(IDatabaseHelper databaseHelper, IUserDAL userDAL, IAddressDAL addressDAL)
        {
            DatabaseHelper = databaseHelper;
            UserDAL = userDAL;
            AddressDAL = addressDAL;
        }
        public List<Student> GetAll()
        {
            Console.WriteLine("Connection open");
            return null;
        }
        public List<Student> GetTopFifteenStudents()
        {
            return new List<Student>();
        }
        public void UpdateStatus(Student student, string status)
        {
            student.Status = status;
            Console.WriteLine("Update user status");
        } 
         public bool CreateStudent(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int userId=UserDAL.AddUser(user, Role.student);
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentId", userId));
            parameters.Add(new SqlParameter("@NationalID", user.Student.NationalId));
            parameters.Add(new SqlParameter("@FirstName", user.Student.FirstName));
            parameters.Add(new SqlParameter("@Surname", user.Student.Surname));
            parameters.Add(new SqlParameter("@PhoneNumber", user.Student.PhoneNumber));
            parameters.Add(new SqlParameter("@DateOfBirth", user.Student.DateofBirth));
            parameters.Add(new SqlParameter("@GuardianName", user.Student.GuardianName));
            bool insert= DatabaseHelper.InsertUpdateData(CreateStudentQuery, parameters);
            insert = AddressDAL.CreateAddress(user.Student.Address, userId);
            return insert;
        }
        List<Student> IStudentDAL.GetAll()
        {
            List<Student> studentList = null;
            Student student;
            var dt = DatabaseHelper.GetData(GetStudentsQuery);
                if (dt.Rows.Count > 0)
                {
                studentList = new List<Student>();
                foreach (DataRow row in dt.Rows)
                {
                    student = new Student();
                    student.FirstName = row["FirstName"].ToString();
                    student.Surname = row["Surname"].ToString();
                    student.NationalId = row["NationalId"].ToString();
                    student.PhoneNumber = row["PhoneNumber"].ToString();
                    student.DateofBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                    student.GuardianName = row["GuardianName"].ToString();
                    studentList.Add(student);
                }
            }
            return studentList;
        }
        List<Student> IStudentDAL.GetTopFifteenStudents()
        {
            throw new System.NotImplementedException();
        }
        private int getStudentId(int userID)
        {
            int UserId = 0;
            string query = @"SELECT StudentId FROM Student WHERE UserId=@UserId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userID));
            DataTable result = DatabaseHelper.QueryConditions(query, parameters);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                UserId = (int)row["StudentId"];
            }
            return UserId;
        }
        public bool isResultAdded(List<Result> listOfResults, int userId)
        {
            bool isResultAdded = false;
            foreach (var result in listOfResults)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SubjectId", result.Subject.SubjectId));
                parameters.Add(new SqlParameter("@GradeId", result.Grade.GradeId));
                parameters.Add(new SqlParameter("@StudentId", userId));
                isResultAdded = DatabaseHelper.InsertData(resultQuery, parameters);
            }
            return isResultAdded;
        }
        public List<Student> GetStudentsWithResults()
        {
            List<Student> students = new List<Student>();
            DataTable result = DatabaseHelper.QueryConditions(GetAllStudentsWithResults, null);
            if (result.Rows.Count > 0)
            {
                List<int> ListStudentId = new List<int>();
                Student student = null;
                List<Result> results = null;
                for (int i=0; i<result.Rows.Count; i++)
                {
                    DataRow row=result.Rows[i];
                    int studentId = (int)row["StudentId"];
                    if (!ListStudentId.Contains(studentId))
                    {
                        ListStudentId.Add(studentId);
                        if (student!=null)
                        {
                            student.Results = results;
                            students.Add(student);
                        }
                        student=new Student();
                        results = new List<Result>();
                    }
                    student.StudentId = studentId;
                    student.FirstName= row["FirstName"].ToString();
                    student.Surname= row["Surname"].ToString();
                    if (row["Status"]==null)
                    {
                        student.Status = null;
                     }
                    else
                    {
                        student.Status = row["Status"].ToString();
                    }
                    Result studentResult=new Result();
                    Subject subject = new Subject();
                    Grade grade= new Grade();   
                    studentResult.ResultId = (int)row["ResultId"];
                    subject.SubjectName= row["SubjectName"].ToString();
                    subject.SubjectId =(int) row["SubjectId"];
                    studentResult.Subject = subject;
                    grade.GradeId = (int)row["GradeId"];
                    grade.GradeName= row["GradeName"].ToString();
                    grade.GradeScore= (int)row["GradeScore"];
                    studentResult.Grade=grade;
                    studentResult.ResultId = (int)row["ResultId"];
                    results.Add(studentResult);
                    if(i==result.Rows.Count-1)
                    {
                        student.Results = results;
                        students.Add(student);
                    }
                } 
            }
            return students;
        }
        public bool GetStudentNationalId(String nationalId)
        {
            bool isNationalIdDuplicate = false;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NationalId", nationalId));
            DataTable result = DatabaseHelper.GetDataWithConditions(GetNationalIdQuery, parameters);
            if (result.Rows.Count > 0)
                isNationalIdDuplicate = true;
            return isNationalIdDuplicate;
        }

        public bool GetStudentPhoneNumber(String phoneNumber)
        {
            bool isPhoneNumberDuplicate = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            DataTable result = DatabaseHelper.GetDataWithConditions(GetPhoneNumberQuery, parameters);
            if (result.Rows.Count > 0)
                isPhoneNumberDuplicate = true;
            return isPhoneNumberDuplicate;
        }
    }
}

