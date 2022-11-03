using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibraries.Repositories;
using AppLibraries.Models;
using AppLibraries.Business_Logic;


namespace AppLibraries.Helper
{
    public class DatabaseHelper
    {
        public DataTable GetDataWithConditions(string query, List<SqlParameter> parameters)
        {
            SqlDatabaseService sqldb = new SqlDatabaseService();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
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

            sqldb.CloseConnection();

            return dt;
        }



        public bool InsertUpdateData(string query, List<SqlParameter> parameters)
        {
            var rowAffected = 0;

            SqlDatabaseService sqldb = new SqlDatabaseService();
            using (SqlCommand cmd = new SqlCommand(query, sqldb.GetSqlConnection()))
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
            sqldb.CloseConnection();
            var result = rowAffected > 0 ? true : false;
            return result;
        }


    }
}
