using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.DataAccessLayer
{
    public interface IAddressDAL
    {
        bool CreateAddress(Address Address, int studentId);
    }
}
