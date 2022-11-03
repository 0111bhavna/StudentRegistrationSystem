using AppLibraries.Business_Logic.Validation;
using AppLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibraries.Data_Access_Layer;

namespace AppLibraries.Business_Logic
{
    public class UserBL : IUserBL
    {
        public IUserDAL _userDal;

        public UserBL()
        {
            this._userDal = new UserDAL();
        }

        public bool AuthenticateUser(LoginModel loginModel)
        {

            return this._userDal.AuthenticateUser(loginModel);
        }

    }
}
