﻿

namespace RepositoryLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
  
        public string Username { get; set; }
  
        public string Email { get; set; }
      
        public string Password { get; set; }
        public Student Student { get; set; }
        public Role Role { get; set; }
        public User()
        {
        }
    }
}
