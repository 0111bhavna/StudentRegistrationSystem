using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;


namespace AppLibraries.Business_Logic
{
    public class SqlDatabaseService
    {
        private SqlConnection sqlConnection = null;
        public SqlDatabaseService()
        {
            String connectionString = @ConfigurationManager.AppSettings["ConnectionString"];
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
