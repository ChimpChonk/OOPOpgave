using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_del_4.Code
{
    internal class Enrollment : IComparable<Enrollment>
    {
        public Students StudentInfo { get; set; }
        public Course CoursesInfo { get; set; }
        public List<Enrollment> EnrollList { get; set; }

        public Enrollment(Students _studentInfo, Course _coursesInfo)
        {
            StudentInfo = _studentInfo;
            CoursesInfo = _coursesInfo;
        }

        public Enrollment()
        {
        }

        public int CompareTo(Enrollment? other)
        {
            if (other != null)
            {
                return StudentInfo.LastName.CompareTo(other.StudentInfo.LastName);
            }

            else return 1;
        }
    }
}
