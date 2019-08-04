using MSUniversity.DAL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.BLL
{
    public class CourseManager
    {
        CourseRepository _repository = new CourseRepository();
        public bool Add(Course course)
        {
            bool IsSaved = _repository.Add(course);
            if (IsSaved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Course> GetAll()
        {
            var courses=_repository.GetAll();
            return courses;
        }
    }
}
