using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveDel4.Code
{
    internal class Course
    {
        public string CourseName { get; set; }

        public Teachers Teachers { get; set; }

        public Course(string _courseName, Teachers _teachers)
        {
            CourseName = _courseName;
            Teachers = _teachers;
        }

        public List<string> StudentList(Enrollment enrollment)
        {
            List<string> students = new();

            foreach (var item in enrollment.EnrollList)
            {
                if (item.CoursesInfo.CourseName == CourseName)
                {
                    string student = $"{item.StudentInfo.FirstName} {item.StudentInfo.LastName}";

                    if (!students.Contains(student))
                    {
                        students.Add(student);
                    }
                }
            }

            return students;
        }
        public void CourseStudentAmount(List<string> students)
        {
            if (students.Count < 8)
            {
                throw new Exception("Faget har mindre en 8 studenter");
            }
            else if (students.Count > 16)
            {
                throw new Exception("Faget har mere en 16 studenter");
            }
        }

    }
}
