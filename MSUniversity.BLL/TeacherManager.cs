using MSUniversity.DAL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.BLL
{
    public class TeacherManager
    {
        TeacherRepository _teacherRepository = new TeacherRepository();
        public bool Add(Teacher teacher)
        {
           bool IsSaved=_teacherRepository.Add(teacher);
            if(IsSaved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Teacher> GetAll()
        {
            var teachers=_teacherRepository.GetAll();
            return teachers;
        }
    }
}
