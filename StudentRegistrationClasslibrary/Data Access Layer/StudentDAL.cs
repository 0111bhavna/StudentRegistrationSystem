using StudentRegistrationClassLibrary.Helper;
using StudentRegistrationClassLibrary.Models;
using System.Data.Common;
using System.Data.SqlClient;
using StudentRegistrationClassLibrary.Business_Logic;
using System.Data;
using StudentRegistrationClassLibrary.Data_Access_Layer;

namespace StudentRegistrationClassLibrary.Data_Access_Layer
{
    public class StudentDAL : IStudentDAL
    {


        private const string CreateStudentQuery = @"Insert into Student
        ( [email], [password])";



        private const string GetStudentsQuery = @"Select [email], [password] from Student";

        DatabaseHelper databaseHelper;
        public StudentDAL()
        {
            this.databaseHelper = new DatabaseHelper();
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

         public bool CreateStudent(Student student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            string Status = "Waiting";
            int UserId = 0;
            string query = @"INSERT INTO Users(Email, Password)";
            query += "VALUES(@Email, @Password)";
            parameters.Add(new SqlParameter("@Email", student.Email));
            parameters.Add(new SqlParameter("@Password", student.Password));
            databaseHelper.InsertUpdateData(query, parameters);
            query = "SELECT UserId FROM Users WHERE Email=@Email";
            DataTable result = databaseHelper.GetDataWithConditions(query, parameters);
            UserId = (int)result.Rows[0]["UserId"];

            parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@NationalID", student.NationalId));
            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@Surname", student.Surname));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@DateOfBirth", student.DateofBirth));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            //parameters.Add(new SqlParameter("@Address", student.Address));
            parameters.Add(new SqlParameter("@UserId", UserId));
            parameters.Add(new SqlParameter("@Status", Status));

            return databaseHelper.InsertUpdateData(CreateStudentQuery, parameters);
        }
    }
}

