using System.Data;
using System.Data.SqlClient;
namespace RepositoryLibrary.DataAccessLayer
{
    public interface IDatabaseConnection
    {
        void NonQuery(SqlCommand command);
        DataTable Query(SqlCommand command);
    }
}
