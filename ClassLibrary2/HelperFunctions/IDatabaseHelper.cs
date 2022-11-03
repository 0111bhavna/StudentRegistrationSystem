using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.HelperFunctions
{
    public interface IDatabaseHelper
    {
        DataTable GetDataWithConditions(string query, List<SqlParameter> parameters);
        bool InsertUpdateData(string query, List<SqlParameter> parameters);

        DataTable GetData(string query);

    }
}
