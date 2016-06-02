using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.IService;
using NAA.Services.Service;
using NAA.Data;


namespace NAA.Controllers
{
    public class ApplicantController : Controller
    {
        private IApplicantService _applicantService;

        public ApplicantController()
        {
            _applicantService = new ApplicantService();
        }

        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/AddApplicant
        [HttpGet]
        public ActionResult AddApplicant()
        {
            return View();
        }

        // POST: Applicant/AddApplicant
        [HttpPost]
        public ActionResult AddApplicant(Applicant applicant)
        {
            return View();
        }

        // GET: Applicant/EditApplicant/5
        public ActionResult EditApplicant(int id)
        {
            return View();
        }

        // POST: Applicant/EditApplicant/5
        [HttpPost]
        public ActionResult EditApplicant(int id, FormCollection collection)
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

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
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
