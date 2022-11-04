using RepositoryLibrary.DataAccessLayer;
using RepositoryLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLibrary.Business_Logic
{
    public class StudentBL : IStudentBL
    {
        private IStudentDAL StudentDAL;
        public StudentBL(IStudentDAL studentDAL)
        {
            StudentDAL = studentDAL;
        }
        public bool CreateStudent(User user)
        {
                var isCreated = false;
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                isCreated = StudentDAL.CreateStudent(user);
            return isCreated;
        }
        private bool ValidateEmailDuplication(string _email)
        {
            var student = StudentDAL.GetAll().FirstOrDefault(s => s.Email.Equals(_email));
            if (student == null)
            {
                return true;
            }
            return false;
        }
        private bool IsNIDUnique(string NID)
        {
            var student = StudentDAL.GetAll().FirstOrDefault(s => s.NationalId.Equals(NID));
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
            var student = StudentDAL.GetAll().FirstOrDefault(s => s.PhoneNumber.Equals(PhoneNumber));
            return student != null;
        }
        public bool AddStudentResult(List<Result> resultList, int userId)
                {
                    bool isResultAdded = false;

                    isResultAdded = StudentDAL.isResultAdded(resultList, userId);

                    return isResultAdded;
                }
    }
}
