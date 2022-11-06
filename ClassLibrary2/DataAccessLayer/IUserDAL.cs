using RepositoryLibrary.Models;
namespace RepositoryLibrary.DataAccessLayer
{
    public interface IUserDAL
    {
        bool AuthenticateUser(LoginModel loginModel);
        int AddUser(User user, Role role);
        Role? GetUserRole(int userId);
    }
}
