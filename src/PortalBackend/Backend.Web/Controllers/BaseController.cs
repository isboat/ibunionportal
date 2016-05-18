﻿using System.Web.Mvc;
using Backend.Logics.AuthenticationModels;

namespace Backend.Web.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get
            {
                return this.HttpContext.User as CustomPrincipal;
            }
        }


        public ActionResult AboutUs()
        {
           
            return View();
        }

        public ActionResult TermsAndConditions()
        {

            return View();
        }

        public ActionResult CookiePolicy()
        {

            return View();
        }

        public ActionResult PrivacyPolicy()
        {

            return View();
        }

        public ActionResult ContactUs()
        {

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}