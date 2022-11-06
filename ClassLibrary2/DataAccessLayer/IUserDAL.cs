using RepositoryLibrary.Models;
using System;
namespace RepositoryLibrary.DataAccessLayer
{
    public interface IUserDAL
    {
        bool AuthenticateUser(LoginModel loginModel);
        int AddUser(User user, Role role);
        Role? GetUserRole(int userId);
        bool GetUserByEmail(String email);
    }
}
