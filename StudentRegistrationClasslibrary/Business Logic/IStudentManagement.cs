using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationClassLibrary.Models;

namespace StudentRegistrationClassLibrary.Business_Logic
{
    public interface IStudentManagement
    {

        string updateStudent();

        void CreateStudent(Student student);
    }
}
