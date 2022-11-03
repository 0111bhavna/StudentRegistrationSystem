using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Enter email")]
        public string email { get; set; }
        

        [Required(ErrorMessage ="Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage ="please Confirm password ")]
        [DataType (DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

     
    }
}
