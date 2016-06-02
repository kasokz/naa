using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IService;
using NAA.Data;
using NAA.Data.BEANS;
using University.Services.Service;

namespace NAA.Controllers
{
    public class ApplicationController : Controller
    {
        private IApplicationService _applicationService;
        private IUniversityService _universityService;

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
            _universityService = new UniversityService();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View(_applicationService.GetApplications());
        }

        public ActionResult CheckApplicationCount(int applicantId)
        {
            IList<Application> applications = _applicationService.GetApplicationsByApplicantId(applicantId);
            if (applications.Count < 5) {
                return RedirectToAction("ChooseUniversity", new { applicantId = applicantId, Controller = "University" });
            } else {
                return RedirectToAction("ApplicationsByApplicantId", new { id = applicantId });
            }
        }

        // GET: Application/AddApplication
        public ActionResult AddApplication(int applicantId, int universityId)
        {
            IList<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var item in University.Services.Service.CourseServiceFactory.getInstance().createCourseService(universityId).GetAllCoursesShort())
            {
                courseList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Name
                    });
            }
            ViewBag.courseList = courseList;
            ViewBag.universityName = _universityService.GetUniversityById(universityId).UniversityName;
            return View();
        }

        //POST: Application/AddApplication
        [HttpPost]
        public ActionResult AddApplication(ApplicationFormBEAN application)
        {
            bool courseIsAlreadyAppliedFor = false;
            foreach (var item in _applicationService.GetApplicationsByApplicantId(application.ApplicantId))
            {
                if (item.CourseName == application.CourseName && item.UniversityId == application.UniversityId)
                {
                    courseIsAlreadyAppliedFor = true;
                }
            }
            if (!courseIsAlreadyAppliedFor)
            {
                _applicationService.AddApplication(application);
            }
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

        [HttpGet]
        public ActionResult DeleteApplicationById(int id)
        {
            return View(_applicationService.GetApplicationDetailsBEANById(id));
        }

        [HttpPost]
        public ActionResult DeleteApplicationById(ApplicationDetailsBEAN applicationBEAN)
        {
            string applicantId = applicationBEAN.ApplicantName;
            _applicationService.DeleteApplicationById(applicationBEAN.Id);
            return RedirectToAction("ApplicationsByApplicantId", new { id = applicantId });
        }
    }
}