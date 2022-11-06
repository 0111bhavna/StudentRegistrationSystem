using RepositoryLibrary.Models;
namespace ServiceLibrary.Business_Logic
{

    public interface IUserBL
        {
            bool AuthenticateUser( LoginModel LoginModel);
            bool DoesEmailExist(string email);
        }
    
}

