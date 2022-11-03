using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationClassLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "name " )]
        public string Username { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
        public Student Student = null;
        public Role Role;
        public User()
        {
        }
    }
}
