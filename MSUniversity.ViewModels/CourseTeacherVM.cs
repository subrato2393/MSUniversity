using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.ViewModels
{
    public class CourseTeacherVM
    {
        public string Code { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public CourseSemester Semester { get; set; }
        public int DepartmentId { get; set; }
    }
    public enum CourseSemester
    {
        SelectSemester,
        First,
        Second,
        Third,
        Four,
        Five,
        Six,
        Seven,
        Eight
    }
}
