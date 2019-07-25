using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.Models
{
    public class CourseEnrollment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
