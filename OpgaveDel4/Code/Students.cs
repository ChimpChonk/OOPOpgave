using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_del_4.Code
{
    sealed class Students : Person
    {
        public int StudentId { get; set; }
        public Students(int _studentId, string _firstName, string _lastName, string _dateOfBirth) : base(_firstName, _lastName, _dateOfBirth)
        {
            StudentId = _studentId;
        }

        public override string? GetAllCourses(Enrollment enrollment)
        {
            StringBuilder sb = new();
            List<string> coursesList = new List<string>();

            sb.Append($"{FirstName} {LastName}:\n");
            foreach (var item in enrollment.EnrollList)
            {
                if (item.StudentInfo.StudentId == StudentId)
                {
                    if (!coursesList.Contains(item.CoursesInfo.CourseName))
                    {
                        coursesList.Add(item.CoursesInfo.CourseName);
                        sb.Append($"{item.CoursesInfo.CourseName}\n");
                    }
                }
            }

            return sb.ToString();
        }
        public override List<string> GetAllCourses(List<Enrollment> enrollment)
        {
            List<string?> courseList = new();
            foreach (var item in enrollment)
            {
                if (item.StudentInfo.StudentId == StudentId)
                {
                    courseList.Add(item.CoursesInfo.CourseName.ToString());
                }
            }

            return courseList;
        }

        public override string ReturnFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
