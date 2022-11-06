using RepositoryLibrary.Models;
using System.Collections.Generic;
namespace ServiceLibrary.Business_Logic
{
    public interface IStudentBL
    {
        bool CreateStudent(User user);

        bool AddStudentResult(List<Result> result, int userId);

        List<Student> GetSortedStudentsByPoints();
        bool DoesNidExist(string nationalId);
        bool DoesPhoneNumberExist(string phoneNumber);
    }
}
