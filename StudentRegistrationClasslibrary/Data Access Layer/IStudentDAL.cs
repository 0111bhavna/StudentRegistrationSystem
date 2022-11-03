using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationClassLibrary.Models;

namespace StudentRegistrationClassLibrary.Data_Access_Layer;

public interface IStudentDAL
{
    List<Student> GetAll();
    void UpdateStatus(Student student, int Status);
    List<Student> GetTopFifteenStudents();
    bool CreateStudent(Student student);

}
