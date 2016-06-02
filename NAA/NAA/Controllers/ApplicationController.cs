using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IService;
using NAA.Data;
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
        public ActionResult AddApplication(Application application)
        {

        }
        public ActionResult ApplicationsByApplicantId(int id)
        {
            return View(_applicationService.GetApplicationsByApplicantId(id));
        }
    }
}