using System;
using System.Data;
using System.Data.SqlClient;
namespace RepositoryLibrary.DataAccessLayer
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private SqlConnection conn = null;
        private void Open()
        {
            string connetionString = "Data Source=L-PW02X092\\SQLEXPRESS;Initial Catalog=\"StudentRegistration SystemDb\";Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
        }
        private void Close()
        {
            conn.Close();
        }
        public void NonQuery(SqlCommand command)
        {
            try
            {
                Open();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);

            }
            finally
            {
                Close();
            }
        }
        public DataTable Query(SqlCommand command)
        {
            DataTable data = null;
            try
            {
                Open();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                Close();
            }
            return data;
       }
        public SqlConnection GetSqlConnection()
        {
            return this.conn;
        }
    }
}
