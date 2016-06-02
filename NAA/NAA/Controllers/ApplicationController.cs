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

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View(_applicationService.getApplications());
        }

        // GET: Application/AddApplication
        public ActionResult AddApplication(int applicantId)
        {
            IList<SelectListItem> universityList = new List<SelectListItem>();
            foreach (var item in new List<University>())
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
            // Save to Database, write function that accepts ApplicationFormBEAN
            return RedirectToAction("Details", new { id = application.Id });
        }

        public ActionResult Details(int id)
        {
            return View(_applicationService.getApplicationById(id));
        }
    }
}