using AppLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibraries.Business_Logic
{
    public interface IStudentBL
    {
        bool CreateStudent(Student Student);
    }
}
