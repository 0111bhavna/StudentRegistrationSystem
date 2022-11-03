using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLibrary.Models;



namespace RepositoryLibrary.HelperFunctions
{
    public class DatabaseHelper: IDatabaseHelper
    {
        private readonly ISqlDatabaseHelper SqlDatabaseHelper;
        public DatabaseHelper(ISqlDatabaseHelper SqlDatabaseHelper)
        {
            this.SqlDatabaseHelper = SqlDatabaseHelper;
        }
        public DataTable GetDataWithConditions(string query, List<SqlParameter> parameters)
        {
           
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, SqlDatabaseHelper.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
            SqlDatabaseHelper.CloseConnection();
            return dt;
        }
        public bool InsertUpdateData(string query, List<SqlParameter> parameters)
        {
            var rowAffected = 0;
          
            using (SqlCommand cmd = new SqlCommand(query, SqlDatabaseHelper.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                rowAffected = cmd.ExecuteNonQuery();
            }
            SqlDatabaseHelper.CloseConnection();
            var result = rowAffected > 0 ? true : false;
            return result;
        }


        public DataTable GetData(string query)
        {

            SqlDatabaseHelper sqldb = new SqlDatabaseHelper();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }

            sqldb.CloseConnection();

            return dt;
        }


        public bool InsertData(string query, List<SqlParameter> parameters)
        {

            SqlDatabaseHelper sqldb = new SqlDatabaseHelper();

            

            var rowAffected = 0;

            using (SqlCommand command = new SqlCommand(query, sqldb.GetSqlConnection()))
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                rowAffected = command.ExecuteNonQuery();
            }
            sqldb.CloseConnection();
            var result = rowAffected > 0 ? true : false;
            return result;
        }

        public DataTable QueryConditions(string query, List<SqlParameter> parameters)
        {
            SqlDatabaseHelper sqldb = new SqlDatabaseHelper();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, sqldb.GetSqlConnection()))
                {

                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }


                    using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                    {
                        sqlData.Fill(data);
                    }
                }
            
                
            }
            catch (Exception Error)
            {
                throw Error;
            }
            sqldb.CloseConnection();
            return data;
        }
    }
}
