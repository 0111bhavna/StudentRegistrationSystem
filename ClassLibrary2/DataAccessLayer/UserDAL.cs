using RepositoryLibrary.DataAccessLayer;
using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RepositoryLibrary.HelperFunctions;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace RepositoryLibrary.DataAccessLayer
{
    public class UserDAL : IUserDAL
    {
        public const string AuthenticationQuery = @"select Password from Users where Email = @Email ";

        public const string GetUserQuery = @"select UserId from Users where Email = @Email ";

        public const string AddUserQuery = @"Insert into Users (Email, RoleId, Password) values(@Email,@RoleId,@Password)";

        private readonly IDatabaseHelper DatabaseHelper;
        public UserDAL(IDatabaseHelper databaseHelper)
        {
            DatabaseHelper = databaseHelper;
        }
        public bool AuthenticateUser(LoginModel LoginModel)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", LoginModel.Email));
            var dt = DatabaseHelper.GetDataWithConditions(AuthenticationQuery, parameters);
            if (dt.Rows.Count > 0)
            {
                string hashedPassword = dt.Rows[0]["Password"].ToString();
                return BCrypt.Net.BCrypt.Verify(LoginModel.Password, hashedPassword);
            }
            return false;
        }

        public int AddUser(User user, Role role)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", user.Email));
            parameters.Add(new SqlParameter("@Password", user.Password));
            parameters.Add(new SqlParameter("@RoleId", (int)role));
            bool add=DatabaseHelper.InsertUpdateData(AddUserQuery, parameters);
            int userId = 0;
            if (add)
            {
                DataTable result=DatabaseHelper.GetDataWithConditions(GetUserQuery, parameters);
                if (result.Rows.Count > 0)
                {
                    userId = (int)result.Rows[0]["UserId"];
                }
            }
            return userId;
        }

        public bool CheckMailDuplicate(User user)
        {
            string query = @"select TOP 1* from users where Email=@Email"; List<SqlParameter> parameters = new List<SqlParameter>(); parameters.Add(new SqlParameter("@Email", user.Email));
            //DataTable results = .Query(query, parameters);
            //if (results.Rows.Count > 0) { return true; }


            return false;
        }






    }
}
