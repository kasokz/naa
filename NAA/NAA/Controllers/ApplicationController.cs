using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IService;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA.Controllers
{
    public class ApplicationController : Controller
    {
        private IApplicationService _applicationService;
        private IUniversityService _universityService;

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View(_applicationService.GetApplications());
        }

        // GET: Application/AddApplication
        public ActionResult AddApplication(int applicantId)
        {
            IList<SelectListItem> universityList = new List<SelectListItem>();
            foreach (var item in _universityService.GetUniversities())
            {
                universityList.Add(
                    new SelectListItem()
                    {
                        Text = item.UniversityName,
                        Value = item.UniversityId.ToString()
                    });
            }
            ViewBag.universityList = universityList;
            return View();
        }

        //POST: Application/AddApplication
        [HttpPost]
        public ActionResult AddApplication(ApplicationFormBEAN application)
        {
            _applicationService.AddApplication(application);
            return RedirectToAction("ApplicationsByApplicantId", new { id = application.ApplicantId });
        }

        public ActionResult Details(int id)
        {
            return View(_applicationService.GetApplicationDetailsBEANById(id));
        }

        public ActionResult ApplicationsByApplicantId(int id)
        {
            ViewBag.applicantId = id;
            return View(_applicationService.GetApplicationListItemBEANSByApplicantId(id));
        }
    }
}