using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLibrary.Models;

namespace ServicesLibrary.Business_Logic
{
        public interface IUserBL
        {
            bool AuthenticateUser( LoginModel LoginModel);
        }
}

