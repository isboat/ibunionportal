using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Backend.Interfaces;
using Backend.ViewModels.Authentication;
using Portal.Common.IoC;
using Portal.Web.Models;

namespace Backend.Web.Controllers
{
    public class AuthController : BaseController
    {

        #region Instances Variables

        private readonly IAuthentication authenticationLogic = IoC.Instance.Resolve<IAuthentication>();

        #endregion
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            if (this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return this.View();
                }

                var response = this.authenticationLogic.Login(request.Username, request.Password);

                if (response != null)
                {
                    var formAuthCookie = new HttpCookie(response.FormsAuthCookieName, response.FormsAuthCookieValue);
                    this.Response.Cookies.Add(formAuthCookie);

                    return this.RedirectToAction("Index", "Home");
                }

                var error = "username or password is incorrect";
                if (response != null && !string.IsNullOrEmpty(response.Message))
                {
                    error = response.Message;
                }

                this.ModelState.AddModelError("Username", error);
                return this.View();
            }
            catch (Exception ex)
            {
                return this.View();
            }
        }
        
        public ActionResult LogOff()
        {
            if (!this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            
            var user = this.User;
            
            FormsAuthentication.SignOut();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
