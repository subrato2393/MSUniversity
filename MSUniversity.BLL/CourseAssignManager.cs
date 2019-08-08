using MSUniversity.DAL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.BLL
{

    public class CourseAssignManager
    {
        CourseAssignRepository _repository = new CourseAssignRepository();
        public bool Add(CourseAssign courseAssign)
        {
            bool IsSaved = _repository.Add(courseAssign);
            if (IsSaved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetRemainingCredit()
        {
            int remainingCredit = _repository.GetRemainningCredit();
            return remainingCredit;
        }
    }
}
