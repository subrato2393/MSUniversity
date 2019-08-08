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
        CourseAssignManager _courseAssignManager = new CourseAssignManager();
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
            if(ModelState.IsValid)
            {
                bool IsSaved=_courseAssignManager.Add(courseAssign);
                if(IsSaved)
                {
                    ViewBag.Message = "Assign Successfully";
                }
                else
                {
                    ViewBag.Message = "Asasign Failed";
                }
            }
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
        public JsonResult GetCreditToTaken(int teacherId)
        {
            var creditTotaken = _teacherManager.GetAll().FirstOrDefault(x => x.Id == teacherId);
            return Json(creditTotaken);
        }
        public JsonResult GetCourseNameAndCredit(int courseId)
        {
            var course = _courseManager.GetAll().FirstOrDefault(x => x.Id == courseId);
            return Json(course);
        }
        public JsonResult GetRemainingCredit()
        {
            var course = _courseAssignManager.GetRemainingCredit();
            return Json(course);
        }
    }
}