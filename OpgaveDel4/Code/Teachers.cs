using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveDel4.Code
{
    sealed class Teachers : Person
    {
        Enrollment enrollmentlist = new();
        public string Department { get; set; }

        public Teachers(string _department, string _firstName, string _lastName, string _dateOfBirth) : base(_firstName, _lastName, _dateOfBirth)
        {
            Department = _department;
        }

        public string TeacherDepartment()
        {
            return $"{FirstName} + {LastName} is a {Department}";
        }

        public override string? GetAllCourses(Enrollment enrollment)
        {
            StringBuilder sb = new();
            List<string> coursesList = new List<string>();

            sb.Append($"{FirstName} {LastName}:\n");
            foreach (var item in enrollment.EnrollList)
            {
                if (item.CoursesInfo.Teachers.FirstName == FirstName && item.CoursesInfo.Teachers.LastName == LastName)
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
        public override List<string?> GetAllCourses(List<Enrollment> enrollment)
        {
            List<string?> coursesList = new List<string?>();
            foreach (var item in enrollment)
            {
                if (item.CoursesInfo.Teachers.FirstName == FirstName && item.CoursesInfo.Teachers.LastName == LastName)
                {
                    if (!coursesList.Contains(item.CoursesInfo.CourseName))
                    {
                        coursesList.Add(item.CoursesInfo.CourseName.ToString());
                    }
                }
            }

            return coursesList;
        }

        public override string ReturnFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
