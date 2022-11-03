using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Business_Logic.Validation
{
    public class Validation
    {

        private bool ValidateEmailDuplication(string email)
        {
            var Userlist = GetU().FirstOrDefault(x => x.EmailAddress.Equals(email));
            return Userlist != null;
        }
    }
}
