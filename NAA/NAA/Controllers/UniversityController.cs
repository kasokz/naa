using NAA.Data.BEANS;
using NAA.Services.IService;
using NAA.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class UniversityController : Controller
    {
        private IUniversityService _universityService;

        public UniversityController()
        {
            _universityService = new UniversityService();
        }
        // GET: University
        public ActionResult Index()
        {
            return View(_universityService.GetUniversities());
        }

        [HttpGet]
        public ActionResult ChooseUniversity(int applicantId)
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
            ViewBag.applicantId = applicantId;
            return View();
        }

        [HttpPost]
        public ActionResult ChooseUniversity(UniversitySelectionBEAN university)
        {
            return RedirectToAction("AddApplication", new
            {
                applicantId = university.ApplicantId,
                universityId = university.UniversityId,
                Controller = "Application"
            });
        }
    }
}