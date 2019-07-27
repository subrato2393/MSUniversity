using MSUniversity.BLL;
using MSUniversity.DAL;
using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        DepartmentManager _manager = new DepartmentManager();
        // GET: Departments
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                bool IsSaved = _manager.Add(department);
                if(IsSaved)
                {
                    ViewBag.Message = "Saved Successfully";
                }
                else
                {
                    ViewBag.Message = "Saved Failed";
                }
            }
           return View();
        }
        public ActionResult GetAllDepartment()
        {
           var departments= _manager.GetAll();
            return View(departments);
        }
    }
}