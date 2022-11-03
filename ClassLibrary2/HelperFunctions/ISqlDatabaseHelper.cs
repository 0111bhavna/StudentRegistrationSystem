using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.HelperFunctions
{
    public interface ISqlDatabaseHelper
    {
        void OpenConnection(SqlConnection Connection);

        void CloseConnection();

        SqlConnection GetSqlConnection();



    }
}
