
using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationClassLibrary.Data_Access_Layer;
using RepositoryLibrary.Helper;
using System.Data.SqlClient;



namespace StudentRegistrationClassLibrary.Data_Access_Layer
{

    public class UserDAL : IUserDAL
    {
        public const string AuthenticationQuery = @"select Password from Users where Email = @email ";

        DatabaseHelper _databaseHelper;

        public UserDAL()
        {
            this._databaseHelper = new DatabaseHelper();
        }
        public bool AuthenticateUser(LoginModel LoginModel)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", LoginModel.Email));

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
