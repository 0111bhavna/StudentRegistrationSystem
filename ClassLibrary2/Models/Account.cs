using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.Models
{
    public class Account
    {
      
        public string email { get; set; }
      
      
        public string Password { get; set; }

     
       
        public string ConfirmPassword { get; set; }
    }
}
