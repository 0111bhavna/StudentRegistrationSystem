using StudentRegistrationClassLibrary.Models;
using StudentRegistrationClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationClassLibrary.Data_Access_Layer;


namespace StudentRegistrationClassLibrary.Business_Logic
{
    public class StudentBL : IStudentBL
    {
        private StudentDAL _studentDAL;
        public StudentBL()
        {
            this._studentDAL = new StudentDAL();
        }
        public bool CreateStudent(Student Student)
        {
            var isCreated = false;
            if (IsNIDUnique(Student.NationalId))
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Student.Password);
                Student.Password = hashedPassword;
                isCreated = this._studentDAL.CreateStudent(Student);
            }
            return isCreated;
        }
        private bool ValidateEmailDuplication(string _email)
        {
            var student = this._studentDAL.GetAll().FirstOrDefault(s => s.Email.Equals(_email));
            if (student == null)
            {
                return true;
            }
            return false;
        }
        private bool IsNIDUnique(string NID)
        {
            var student = this._studentDAL.GetAll().FirstOrDefault(s => s.NationalId.Equals(NID));
            if (student == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidatePhoneDuplication(string PhoneNumber)
        {
            var student = this._studentDAL.GetAll().FirstOrDefault(s => s.PhoneNumber.Equals(PhoneNumber));
            return student != null;
        }       
    }
}
