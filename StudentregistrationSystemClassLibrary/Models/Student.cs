
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationClassLibrary.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string NationalId { get; private set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GuardianName { get; set; }
        public Result Result { get; set; }
        public int Status { get; set; }
    }
}
