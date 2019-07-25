using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.Models
{
    public class AllocateClassRoom
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
    }
}
