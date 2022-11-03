using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RepositoryLibrary.HelperFunctions
{
    public class SqlDatabaseHelper: ISqlDatabaseHelper

    {

        //string ConnectionString = @"Data Source=L-PW02X092\SQLEXPRESS;Initial Catalog=""StudentRegistration SystemDb"";Integrated Security=True";
        private string connectionString= @ConfigurationManager.AppSettings["ConnectionString"];
        private SqlConnection sqlConnection;
        public SqlDatabaseHelper()
        {
            //String connectionString = @ConfigurationManager.AppSettings["ConnectionString"];
            if (this.sqlConnection == null)
            {
                this.sqlConnection = new SqlConnection(connectionString);
                OpenConnection(this.sqlConnection);
            }
        }
        public void OpenConnection(SqlConnection Connection)
        {
            Connection.Open();
        }
        public void CloseConnection()
        {
            this.sqlConnection.Close();
        }
        public SqlConnection GetSqlConnection()
        {
            return this.sqlConnection;
        }
    }
}
