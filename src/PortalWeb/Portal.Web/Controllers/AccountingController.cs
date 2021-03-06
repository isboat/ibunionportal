﻿using System.Web.Mvc;
using Portal.Common.IoC;
using Portal.Web.Interfaces;
using Wams.Web.Controllers;

namespace Portal.Web.Controllers
{
    public class AccountingController : BaseController
    {
        #region Instances Variables

        private readonly IAccounting accounting = IoC.Instance.Resolve<IAccounting>();

        #endregion

        public ActionResult TotalMonthlyDues()
        {
            return View();
        }

        public ActionResult GetTotalMonthlyDues(int year, string mType)
        {
            var data = this.accounting.TotalMonthlyDues(year, mType);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Investment

        public ActionResult InvestmentView()
        {
            return View();
        }

        public ActionResult GetInvestmentData(int year, string mType)
        {
            var result = this.accounting.InvestmentData(year, mType);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // POST: Accounting/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accounting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
