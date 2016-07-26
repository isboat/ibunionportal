using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frontpage.Interfaces;
using Frontpage.ViewModels.Demo;
using Portal.Common.IoC;

namespace Frontpage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoLogic demoLogic = IoC.Instance.Resolve<IDemoLogic>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStarted(string firstname, string lastname, string email)
        {
            var model = new DemoRequest
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetStarted(DemoRequest request)
        {
            if (request == null) return View(new DemoRequest());
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = this.demoLogic.RequestDemo(request);
            return View("BaseResponse", response);
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