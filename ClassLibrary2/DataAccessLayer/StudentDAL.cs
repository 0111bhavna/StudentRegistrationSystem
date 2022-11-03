using RepositoryLibrary.HelperFunctions;
using RepositoryLibrary.Models;
using System.Data.Common;
using System.Data.SqlClient;
using RepositoryLibrary.DataAccessLayer;
using System.Data;
using System.Collections.Generic;
using System;
using ClassLibrary2.DataAccessLayer;

namespace RepositoryLibrary.DataAccessLayer
{
    public class StudentDAL : IStudentDAL
    {
        private const string CreateStudentQuery = @"Insert into Student ([StudentId], [NationalId],[FirstName],[Surname],[PhoneNumber],[DateOfBirth],[GuardianName])
                                                    values (@StudentId,@NationalId, @FirstName,@Surname,@PhoneNumber, @DateOfBirth, @GuardianName) ";


        private const string GetStudentsQuery = @"Select [FirstName], [Surname], [NationalId],[PhoneNumber], [DateOfBirth], [GuardianName]from Student";
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
        public void UpdateStatus(Student student, int status)
        {
            student.Status = status;
            Console.WriteLine("Update user status");
        } 
         public bool CreateStudent(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string Status = "Waiting";
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
                   // student.Address = row["address"].ToString();
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
    }
}

