using MSUniversity.BLL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSUniversity.Controllers
{
    public class CoursesController : Controller
    {
        CourseManager _manager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(),"Id","Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
               bool IsSaved= _manager.Add(course);
                if (IsSaved)
                {
                    ViewBag.Message = "Saved Successfully";
                }
                else
                {
                    ViewBag.Message = "Saved Failed";
                }
            }
            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(),"Id", "Name");
            return View();
        }
    }
}