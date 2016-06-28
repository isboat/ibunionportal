using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frontpage.Interfaces;
using Portal.Common.IoC;

namespace Frontpage.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IDemoLogic demoLogic = IoC.Instance.Resolve<IDemoLogic>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}