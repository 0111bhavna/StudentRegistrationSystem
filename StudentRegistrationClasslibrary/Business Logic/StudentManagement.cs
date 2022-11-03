using StudentRegistrationClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationClassLibrary.Repositories;


namespace StudentRegistrationClassLibrary.Business_Logic
{
    public class StudentManagement : IStudentManagement
    {

        int status = 1;

        public void CreateStudent(Student student)
        {

            //this.StudentDAL.CreateStudent();
        }

        public string updateStudent()
        {
            if (status == 1)
            {
                return "student record successfully updated";
            }
            else
            {
                return "Modification failed";
            }
        }
    }
}
