using StudentRegistrationClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationClassLibrary.Data_Access_Layer
{
    public interface IUserDAL
    {

        bool AuthenticateUser(LoginModel loginModel);
    }
}
