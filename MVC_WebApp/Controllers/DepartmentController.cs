using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        IDataAccessService<Department, int> deptServ;
        public DepartmentController()
        {
            deptServ = new DepartmentDataService();
        }

        // GET: Department
        public ActionResult Index()
        {
            var records = deptServ.Get();
            return View(records);
        }

        public ActionResult Create()
        {
            // Return A View with Empty Departmet Data
            return View(new Department());
        }

        [HttpPost]
        public ActionResult Create(Department department) 
        {
            // Use Vaidations
            if (ModelState.IsValid)
            {
                //Save
                var record = deptServ.Create(department);
                // Redirect to Index action from the 
                // Currently Executing Controller
                return RedirectToAction("Index");
            }
            else 
            {
              // Stay on Same Page
              return View(department);
            }
        }

        public ActionResult Edit(int id)
        {
            var record = deptServ.Get(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(int id, Department department) 
        {
            if (ModelState.IsValid)
            {
                var record = deptServ.Update(id, department);
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        public ActionResult Delete(int id) 
        {
            var rec = deptServ.Delete(id);
            return RedirectToAction("Index");
        }

    }
}