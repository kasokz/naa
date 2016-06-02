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
            ActionResult result;
            if(_applicantService.GetApplicants().Count() == 0)
            {
               result = RedirectToAction("AddApplicant");
            } else 
            {
                Applicant applicant = _applicantService.GetApplicants().First();
                result = RedirectToAction("Details", new { id = applicant.Id });
            }
            return result;
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View(_applicantService.GetApplicantById(id));
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
            _applicantService.AddApplicant(applicant);
            return RedirectToAction("Details", new { id = applicant.Id });
        }

        // GET: Applicant/EditApplicant/5
        public ActionResult EditApplicant(int id)
        {
            return View(_applicantService.GetApplicantById(id));
        }

        // POST: Applicant/EditApplicant/5
        [HttpPost]
        public ActionResult EditApplicant(Applicant applicant)
        {
            _applicantService.EditApplicant(applicant);
            return RedirectToAction("Details", new { id = applicant.Id });
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
