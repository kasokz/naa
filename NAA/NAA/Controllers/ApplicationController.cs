using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Service.Service;
using NAA.Service.IService;

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
    }
}