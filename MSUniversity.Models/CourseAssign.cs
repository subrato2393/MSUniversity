using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.Models
{
    public class CourseAssign
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
