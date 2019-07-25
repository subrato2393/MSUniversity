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
           DepartmentManager _manager = new DepartmentManager();
           bool IsSaved=_manager.Add(department);
           return View();
        }
    }
}