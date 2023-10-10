using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_WebApp.Controllers
{
    public class SPAController : Controller
    {
        // GET: SPA
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("List");
        }
        public ActionResult Add()
        {
            return PartialView("Add");
        }
        public ActionResult Edit()
        {
            return PartialView("Edit");
        }
        public ActionResult Delete()
        {
            return PartialView("Delete");
        }


    }
}