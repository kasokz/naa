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
    }
}