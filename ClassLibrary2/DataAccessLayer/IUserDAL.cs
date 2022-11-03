using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.DataAccessLayer
{
    public interface IUserDAL
    {
        bool AuthenticateUser(LoginModel loginModel);
        int AddUser(User user, Role role);
    }
}
