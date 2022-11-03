
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Models
{
    public class Student
    {

        public string StudentId { get; set; }

        [Required(ErrorMessage = "password is required")]

        // set to required format

        [DisplayFormat(DataFormatString = "{0:d}")]
        public string NationalId { get; private set; }

        [Required(ErrorMessage = "password is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }

        public Result Result { get; set; }

        public int Status { get; set; }


    }
}
