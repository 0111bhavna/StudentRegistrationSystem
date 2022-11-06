using RepositoryLibrary.DataAccessLayer;
using RepositoryLibrary.Models;
using ServiceLibrary.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ServiceLibrary.Business_Logic
{
    public class Validation: IValidation
    {
        private IUserDAL userDAL;

        public Validation(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public bool CheckMailDuplicate(String email)
        {
            /*
            string query = @"select TOP 1* from users where EmailAddress=@EmailAddress"; List<SqlParameter> parameters = new List<SqlParameter>(); parameters.Add(new SqlParameter("@EmailAddress", email));

            DataTable results = connection.Query(query, parameters);

            if (results.Rows.Count > 0) { return true; }*/
            return false;

            
        }

        /*
        public static bool isValid(string number)
        {
            string expression = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]
                {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";

            Regex re = new Regex(expression);

   
            if (re.IsMatch(number))
                return (true);
            else
                return (false);
        }

        */
    }
}
