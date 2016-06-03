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

        public ActionResult CheckApplicationCount(int applicantId)
        {
            if (_applicationService.GetApplicationsByApplicantId(applicantId).Count < ApplicationService.MAXAPPLICATIONS) 
            {
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
            ViewBag.applicantId = applicantId;
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

        public ActionResult InitDelete(int id)
        {
            ApplicationDetailsBEAN applicationBEAN = _applicationService.GetApplicationDetailsBEANById(id);
            return (_applicationService.ApplicationIsDeletable(id)) ?  
                RedirectToAction("DeleteApplication", new { id = id }) : 
                RedirectToAction("ApplicationsByApplicantId", new { id = applicationBEAN.ApplicantId });
        }

        [HttpGet]
        public ActionResult DeleteApplication(int id)
        {
            return View(_applicationService.GetApplicationDetailsBEANById(id));
        }

        [HttpPost]
        public ActionResult DeleteApplication(ApplicationDetailsBEAN applicationBEAN)
        {
            int applicantId = _applicationService.GetApplicationDetailsBEANById(applicationBEAN.Id).ApplicantId;
            _applicationService.DeleteApplicationById(applicationBEAN.Id);
            return RedirectToAction("ApplicationsByApplicantId", new { id = applicantId });
        }

        public ActionResult InitFirm(int id) {
            ApplicationDetailsBEAN applicationBEAN = _applicationService.GetApplicationDetailsBEANById(id);
            ActionResult result = RedirectToAction("ApplicationsByApplicantId", new { id = applicationBEAN.ApplicantId });
            if (_applicationService.ApplicationIsFirmable(id)) {
                 result = View(applicationBEAN);
            }
            return result;
        }

        public ActionResult FirmApplication(int id)
        {
            _applicationService.FirmApplication(id);
            return RedirectToAction("ApplicationsByApplicantId", new { id = _applicationService.GetApplicationById(id).ApplicantId });
        }
    }
}