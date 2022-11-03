using AppLibraries.Business_Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace AppLibraries.Services
{
    public class UserManagement : IUserManagement
    {

        int status = 1;
        
        public string Delete()
        {
            if (status == 1)
            {
                return "successful deletion";
            }

            else
            {
                return "Deletion failed";
            }
        }
        public string login()
        {

            if (status == 1)
            {
                return "login successful";
            }
            

            else
            {
                return "login failed";
            }
            
        }

        public string logout()
        {
            if (status == 1)
            {
                return "logout successful";
            }

            else
            {
                return "logout  failed";
            }
        }

        public string Update()
        {

            if (status == 1)
            {
                return "user record updated";
            }
            else
            {
                return "modification failed";
            }
                
        }

        public string UserRegistration()
        {
            throw new NotImplementedException();
        }

    }
}
