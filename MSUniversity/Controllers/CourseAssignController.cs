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
        TeacherManager _teacherManager = new TeacherManager();
        // GET: CourseAssign
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            var defaultSelectListItem = new List<SelectListItem>()
            {
               new SelectListItem(){Value="",Text="Select"}
            };
            ViewBag.CourseId = defaultSelectListItem;
            ViewBag.TeacherId = defaultSelectListItem;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseAssign courseAssign)
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            var defaultSelectListItem = new List<SelectListItem>()
            {
               new SelectListItem(){Value="",Text="Select"}
            };
            ViewBag.CourseId = defaultSelectListItem;
            ViewBag.TeacherId = defaultSelectListItem;
            return View();
        }
        public JsonResult GetTeacherByDeptId(int departmentId)
        {
            var teachers = _teacherManager.GetAll().Where(x => x.DepartmentId == departmentId);
            return Json(teachers);
        }
        public JsonResult GetCourseByDeptId(int departmentId)
        {
            var courses = _courseManager.GetAll().Where(x => x.DepartmentId == departmentId);
            return Json(courses);
        }
        //public JsonResult GetCreditToTaken(int teacherId)
        //{
        //    var creditTotaken=_teacherManager.GetAll().FirstOrDefault(x=>x.i)
        //}
    }
}