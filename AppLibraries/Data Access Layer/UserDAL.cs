using AppLibraries.Business_Logic.Validation;
using AppLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibraries.Data_Access_Layer;
using AppLibraries.Helper;
using System.Data.SqlClient;


namespace AppLibraries.Data_Access_Layer
{

    public class UserDAL : IUserDAL
    {
        public const string AuthenticationQuery = @"select Password from Users where Email = @Email ";

        DatabaseHelper _databaseHelper;

        public UserDAL()
        {
            this._databaseHelper = new DatabaseHelper();
        }
        public bool AuthenticateUser(LoginModel LoginModel)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", LoginModel.Email));

            var dt = _databaseHelper.GetDataWithConditions(AuthenticationQuery, parameters);
            if (dt.Rows.Count > 0)
            {
                string hashedPassword = dt.Rows[0]["Password"].ToString();
                return BCrypt.Net.BCrypt.Verify(LoginModel.Password, hashedPassword);
            }

            return false;
        }

    }



}
