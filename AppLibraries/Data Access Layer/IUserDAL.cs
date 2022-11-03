using AppLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Data_Access_Layer
{
    public interface IUserDAL
    {

        bool AuthenticateUser(LoginModel loginModel);
    }
}
