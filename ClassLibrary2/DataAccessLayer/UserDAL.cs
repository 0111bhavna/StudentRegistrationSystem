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
using System.Web;

namespace RepositoryLibrary.DataAccessLayer
{
    public class UserDAL : IUserDAL
    {
        public const string AuthenticationQuery = @"select UserId, Password from Users where Email = @Email ";

        public const string GetUserQuery = @"select UserId from Users where Email = @Email ";

        public const string AddUserQuery = @"Insert into Users (Email, RoleId, Password) values(@Email,@RoleId,@Password)";

        public const string GetRoleQuery = @"select RoleId from Users where UserId = @UserId";

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
                bool isUserValid= BCrypt.Net.BCrypt.Verify(LoginModel.Password, hashedPassword);
                if (isUserValid)
                {
                    HttpContext.Current.Session["UserId"] = (int)dt.Rows[0]["UserId"];
                    Role? role = GetUserRole((int)dt.Rows[0]["UserId"]);
                    HttpContext.Current.Session["Role"]=role.ToString();
                }
                return isUserValid;
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

        public Role? GetUserRole(int userId)
        {
            Role? role = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            DataTable result = DatabaseHelper.QueryConditions(GetRoleQuery, parameters);
            if (result.Rows.Count > 0)
            {
                role = (Role)Enum.Parse(typeof(Role),(result.Rows[0]["RoleId"].ToString()));
            }
            return role;
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
