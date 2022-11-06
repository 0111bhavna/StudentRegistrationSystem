using RepositoryLibrary.DataAccessLayer;
using RepositoryLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLibrary.Business_Logic
{
    public class StudentBL : IStudentBL
    {
        private IStudentDAL StudentDAL;
        public StudentBL(IStudentDAL studentDAL)
        {
            StudentDAL = studentDAL;
        }
        public bool CreateStudent(User user)
        {
                var isCreated = false;
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                isCreated = StudentDAL.CreateStudent(user);
            return isCreated;
        }
        public bool AddStudentResult(List<Result> resultList, int userId)
        {
                    bool isResultAdded = false;
                    isResultAdded = StudentDAL.isResultAdded(resultList, userId);
                    return isResultAdded;
        }
        public List<Student> GetSortedStudentsByPoints()
        {
            List<Student> students = StudentDAL.GetStudentsWithResults();
            List<Student> sortedListStudents=null;
            if (students != null)
            {
                List<Student> studentsWithPoints = new List<Student>();
                foreach (var student in students)
                {
                    student.TotalScore=CalculatePoints(student);
                    studentsWithPoints.Add(student);
                }
                sortedListStudents=studentsWithPoints.OrderByDescending(stud => stud.TotalScore).ToList();

                if (sortedListStudents.Any(stud => string.IsNullOrEmpty(stud.Status))) 
                {
                   return  AssignStudentStatus(sortedListStudents);
                }    
            }
            return sortedListStudents;
        }
        private List<Student> AssignStudentStatus(List<Student> student)
        {
            if (student != null)
            {
                if(student.Count > 15)
                {
                    for (int count = 0; count < 15; count++)
                    {
                        if(student[count].TotalScore < 10)
                        {
                            student[count].Status = Status.rejected.ToString();
                        }
                        else
                        {
                            student[count].Status = Status.Accepted.ToString();
                        }
                    }
                    for (int count = 15; count < student.Count; count++)
                    {
                        if (student[count].TotalScore < 10)
                        {
                            student[count].Status = Status.rejected.ToString();
                        }

                        else
                        {
                            student[count].Status = Status.Waiting.ToString();
                        }
                    }
                }
                else
                {
                    for (int count = 0; count < student.Count; count++)
                    {
                        if (student[count].TotalScore < 10)
                        {
                            student[count].Status = Status.rejected.ToString();
                        }
                        else
                        {
                            student[count].Status = Status.Accepted.ToString();
                        }
                    }
                }
            }
            return student;
        }
        private int CalculatePoints(Student student)
        {
            int totalPoints = 0;
            if (student != null)
            {
                foreach(var result in student.Results)
                {
                    totalPoints += result.Grade.GradeScore;
                }
            }
            return totalPoints;
        }
        public bool DoesNidExist(string nationalId)
        {
            return StudentDAL.GetStudentNationalId(nationalId);
        }
        public bool DoesPhoneNumberExist(string phoneNumber)
        {
            return StudentDAL.GetStudentPhoneNumber(phoneNumber);
        }
    }
}
