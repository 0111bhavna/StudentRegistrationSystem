using RepositoryLibrary.Models;
namespace ServiceLibrary.Business_Logic
{
    public interface IStudentManagement
    {

        string updateStudent();

        void CreateStudent(Student student);
    }
}
