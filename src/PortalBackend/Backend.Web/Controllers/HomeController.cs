using System.Web;
using System.Web.Mvc;
using Backend.Interfaces;
using Backend.ViewModels.Demo;
using Portal.Common.IoC;
using Backend.ViewModels;
namespace Backend.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDemoLogic demoLogic = IoC.Instance.Resolve<IDemoLogic>();
        private readonly IAssociationLogic associationLogic = IoC.Instance.Resolve<IAssociationLogic>();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Demo()
        {
            var req = new DemoRequestViewModel();
            return View(req);
        }

        public ActionResult Demo(DemoRequestViewModel request)
        {
            var response = demoLogic.RequestDemo(request);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}