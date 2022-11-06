using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLibrary.Models;

namespace RepositoryLibrary.DataAccessLayer
{ 
public interface IStudentDAL
{
    List<Student> GetAll();
    void UpdateStatus(Student student, string Status);
    List<Student> GetTopFifteenStudents();
    bool CreateStudent(User user);

    bool isResultAdded(List<Result> listOfResults, int userId);

        List<Student> GetStudentsWithResults();
    }
}


