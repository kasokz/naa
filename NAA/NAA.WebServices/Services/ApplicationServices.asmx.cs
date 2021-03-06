﻿using NAA.Data.BEANS;
using NAA.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NAA.Data;

namespace NAA.WebServices.Services
{
    /// <summary>
    /// Summary description for ApplicationServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ApplicationServices : System.Web.Services.WebService
    {
        private ApplicationService _applicationService;

        public ApplicationServices()
        {
            _applicationService = new ApplicationService();
        }

        [WebMethod]
        public List<ApplicationBEAN> GetApplicationsByUniversityName(string name)
        {
            return new List<ApplicationBEAN>(_applicationService.GetApplicationsByUniversityName(name));
        }

        [WebMethod]
        public void RejectApplication(int id, string reason)
        {
            Application application = _applicationService.GetApplicationById(id);
            //Always possible except for Unconditional Offer
            if (application.UniversityOffer != "U")
            {
                application.UniversityOffer = "R"; //Rejected
                application.UniversityComment = reason;
                _applicationService.EditApplication(application);
            }
        }

        [WebMethod]
        public void AcceptApplication(int id)
        {
            Application application = _applicationService.GetApplicationById(id);
            //Only possible if application is in 'Pending'-state
            if (application.UniversityOffer == "P")
            {
                application.UniversityOffer = "U"; //Unconditional
                application.UniversityComment = "Accepted without Condition. Congratulations!";
                _applicationService.EditApplication(application);
            }
        }

        [WebMethod]
        public void AcceptApplicationWithCondition(int id, string condition)
        {
            Application application = _applicationService.GetApplicationById(id);
            //Always possible except for Unconditional Offer
            if (application.UniversityOffer != "U")
            {
                application.UniversityOffer = "C"; //Conditional
                application.UniversityComment = condition;
                _applicationService.EditApplication(application);
            }
        }
    }
}
