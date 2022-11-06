using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
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
        bool GetStudentNationalId(String nationalId);
        bool GetStudentPhoneNumber(String phoneNumber);


    }
}


