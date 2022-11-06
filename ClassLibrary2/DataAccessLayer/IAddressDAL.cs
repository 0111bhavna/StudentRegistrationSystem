using RepositoryLibrary.Models;
namespace ClassLibrary2.DataAccessLayer
{
    public interface IAddressDAL
    {
        bool CreateAddress(Address Address, int studentId);
    }
}
