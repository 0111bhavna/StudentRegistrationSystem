using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace RepositoryLibrary.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GuardianName { get; set; }
        public Address Address { get; set; }
        public string Status { get; set; }
        public int TotalScore { get; set; }
        public List<Result> Results { get; set; }
        public Student()
        {
            Results = new List<Result>();
        }
    }
}
