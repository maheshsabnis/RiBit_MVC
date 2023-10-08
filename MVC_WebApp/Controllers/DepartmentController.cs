using MVC_WebApp.CustomFilters;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_WebApp.Controllers
{
   // [LogFilter]
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
            //try
            //{
                // Use Vaidations
                if (ModelState.IsValid)
                {
                    if (IsUniqueIdExist(department.DeptUniqueId))
                        throw new Exception("Sorry! THe Value for DeptUniqueId is already exist");
                    var result = deptServ.Create(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    // Stay on Same Page
                    return View(department);
                }
            //}
            //catch (Exception ex)
            //{
            //    // 1. HarxCoded VAlues for COntroller and Action MAtethod
            //    //return View("Error", new HandleErrorInfo(ex,"Department", "Create"));
            //    // 2. Using ROuteData to read ROute Expression
            //    // For Controller and Action
            //    return View("Error", new HandleErrorInfo(ex, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString()));
            //}
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


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    //1. Handle the exception so that the current execution Process is complete
        //    filterContext.ExceptionHandled = true;
        //    // 2.Read the exception
        //    Exception ex = filterContext.Exception;

        //    // 3. Create a ViewData
        //    ViewDataDictionary vData = new ViewDataDictionary();
        //    vData["controller"] = filterContext.RouteData.Values["controller"];
        //    vData["action"] = filterContext.RouteData.Values["action"];
        //    vData["errorMessage"] = ex.Message;

        //    // 4. Set the Result
        //    filterContext.Result = new ViewResult()
        //    { 
        //       ViewName = "Error",
        //       ViewData = vData 
        //    };

        //}

        private bool IsUniqueIdExist(string uid)
        { 
            if(string.IsNullOrEmpty(uid)) return false;

            var dept = (from d in deptServ.Get()
                       where d.DeptUniqueId.Trim() == uid.Trim()
                       select d).FirstOrDefault();
            if(dept != null)
                return true;
            return false;

        }

        public ActionResult ShowDetails(int id)
        {
            TempData["DeptNo"] = id;
            return RedirectToAction("Index", "Employee");
        }

    }
}