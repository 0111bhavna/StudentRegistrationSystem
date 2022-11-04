using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLibrary.DataAccessLayer;
using System.Web;

namespace ServiceLibrary.Business_Logic
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL UserDal;
        public UserBL(IUserDAL userDAL)
        {
            UserDal = userDAL;
        }
        public bool AuthenticateUser(LoginModel loginModel)
        {
            return UserDal.AuthenticateUser(loginModel);
        }


    }
}
