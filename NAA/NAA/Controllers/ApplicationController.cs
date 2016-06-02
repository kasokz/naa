using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IService;

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

        public ActionResult ApplicationsByApplicantId(int id)
        {
            return View(_applicationService.GetApplicationsByApplicantId(id));
        }
    }
}