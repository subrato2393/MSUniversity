using MSUniversity.DAL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.BLL
{
    public class DepartmentManager
    {
        DepartmentRepository _repository = new DepartmentRepository();
        public bool Add(Department department)
        {
           bool IsSaved=_repository.Add(department);
            if(IsSaved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
