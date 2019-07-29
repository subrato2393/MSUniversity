using MSUniversity.BLL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSUniversity.Controllers
{
    public class CourseAssignController : Controller
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        CourseManager _courseManager = new CourseManager();
        // GET: CourseAssign
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            //ViewBag.CourseId = new SelectList(_courseManager., "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseAssign courseAssign)
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            return View();
        }
    }
}