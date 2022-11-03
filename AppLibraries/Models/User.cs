using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Models
{
    public class User
    {


        public int UserId { get; private set; }

        [Required(ErrorMessage = "name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

        public Student _student = null;
        public Role _role;

        public User()
        {

        }


    }
}
