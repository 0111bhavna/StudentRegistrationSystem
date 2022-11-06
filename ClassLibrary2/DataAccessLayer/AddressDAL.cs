using RepositoryLibrary.HelperFunctions;
using RepositoryLibrary.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ClassLibrary2.DataAccessLayer
{
    public class AddressDAL: IAddressDAL
    {
        public const string GetAddressQuery = @"select AddressId from Address where Email = @Email ";
        public const string AddAddressQuery = @"Insert into Address (Street, City, Country,StudentId) values(@Street, @City, @Country,@StudentId)";
        private readonly IDatabaseHelper DatabaseHelper;
        public AddressDAL(IDatabaseHelper databaseHelper)
        {
            DatabaseHelper = databaseHelper;
        }
        public bool CreateAddress(Address Address, int studentId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@City", Address.City ));
            parameters.Add(new SqlParameter("@Street", Address.Street));
            parameters.Add(new SqlParameter("@Country", Address.Country));
            parameters.Add(new SqlParameter("@StudentId", studentId));
            bool add = DatabaseHelper.InsertUpdateData(AddAddressQuery, parameters);
            return add;
        }
    }
}
