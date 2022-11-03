using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationClassLibrary.Repositories
{
    public interface IDatabaseConnection
    {
        void NonQuery(SqlCommand command);
        DataTable Query(SqlCommand command);
    }
}
