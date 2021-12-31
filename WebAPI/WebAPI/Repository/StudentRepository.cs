using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class StudentRepository : GenericRepository<Student>
    {
        public IEnumerable<StudentModel> SelectAll()
        {
            List<Student> students = _tables.ToList();
            List<StudentModel> result = new List<StudentModel>();

            foreach(Student student in students)
            {
                StudentModel newStudent = new StudentModel
                {
                    StudentID = student.StudentID,
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    EnrollmentDate = student.EnrollmentDate
                };
                result.Add(newStudent);
            }
            return result;
        }
    }
}