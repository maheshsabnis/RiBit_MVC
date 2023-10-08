using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        IDataAccessService<Employee, int> empServ;
        IDataAccessService<Department, int> deptServ;
        public EmployeeController()
        {
            empServ = new EmployeeDataService();
            deptServ = new DepartmentDataService();
        }

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> records = new List<Employee>();
            // 1. REad data from TempData
            int dno = Convert.ToInt32(TempData["DeptNo"]);

            if (dno > 0)
            {
                records = empServ.Get().Where(e => e.DeptNo == dno).ToList();
            }
            else
            {
                records = empServ.Get().ToList();
            }
            // Keep the TempData
            TempData.Keep();
            return View(records);
        }

        public ActionResult Create()
        {
            int dno = Convert.ToInt32(TempData["DeptNo"]);
            // Return A View with Empty Departmet Data
            // Along with an EMpty Employee Object pass
            // List of Departments
            // ViewBag is dynamic dictoonary to pass data
            // across View and COntroller using Action Method
            // ViewBag can be used to pass additional data to Veiw other than MOdel
            // ViewBag can be used to pass additional data to Veiw other than MOdel

            ViewBag.DeptNo = new SelectList(deptServ.Get(),"DeptNo", "DeptName");

            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee Employee) 
        {
            // Use Vaidations
            if (ModelState.IsValid)
            {
                //Save
                var record = empServ.Create(Employee);
                // Redirect to Index action from the 
                // Currently Executing Controller
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.DeptNo = new SelectList(deptServ.Get(), "DeptNo", "DeptName");

                // Stay on Same Page
                return View(Employee);
            }
        }

        public ActionResult Edit(int id)
        {
            var record = empServ.Get(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee Employee) 
        {
            if (ModelState.IsValid)
            {
                var record = empServ.Update(id, Employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(Employee);
            }
        }

        public ActionResult Delete(int id) 
        {
            var rec = empServ.Delete(id);
            return RedirectToAction("Index");
        }

    }
}