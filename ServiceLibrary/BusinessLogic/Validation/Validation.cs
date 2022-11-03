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
    }
}
