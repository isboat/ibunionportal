using System.Web;
using System.Web.Mvc;
using Portal.Web.ViewModels;
using Wams.Web.Controllers;

namespace Portal.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HomepageViewModel();
            
            var qs = this.Request.QueryString["reqclient"];
            if (!string.IsNullOrEmpty(qs))
            {
                this.Response.Cookies.Add(new HttpCookie("reqclient", qs));
                model.ShowSlider = qs != "android";
            }
            else
            {
                var cookie = this.Request.Cookies["reqclient"];
                model.ShowSlider = cookie == null || cookie.Value != "android";
            }

            return this.View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}