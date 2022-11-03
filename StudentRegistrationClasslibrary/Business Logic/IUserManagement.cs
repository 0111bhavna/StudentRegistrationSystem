using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationClassLibrary.Business_Logic
{
    public interface IUserManagement
    {
        string login();

        string logout();

       
        string Update();
        string Delete(); 

        string UserRegistration();


    }
 
}
