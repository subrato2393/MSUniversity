using MSUniversity.BLL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSUniversity.Controllers
{
    public class TeachersController : Controller
    {
        TeacherManager _teacherManager = new TeacherManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        // GET: Teachers
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if(ModelState.IsValid)
            {
                bool IsSaved = _teacherManager.Add(teacher);
                if(IsSaved)
                {
                    ViewBag.Message = "Saved Successfully";
                }
                else
                {
                    ViewBag.Message = "Saved Failed";
                }
            }
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            return View();
        }

    }
}