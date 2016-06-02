using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Services.IService;
using NAA.Data.DAO;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA.Services.Service
{
    public class ApplicationService : IApplicationService
    {
        private ApplicationDAO _applicationDAO;

        public ApplicationService()
        {
            _applicationDAO = new ApplicationDAO();
        }

        public IList<Application> getApplications()
        {
            return _applicationDAO.GetApplications();
        }

        public Application getApplicationById(int id)
        {
            return _applicationDAO.GetApplicationById(id);
        }

        public IList<Application> GetApplicationsByApplicantId(int id)
        {
            return _applicationDAO.GetApplicationsByApplicantId(id);
        }

        public IList<ApplicationBEAN> GetApplicationBEANsByApplicantId(int id)
        {
            return _applicationDAO.GetApplicationBEANsByApplicantId(id);
        }

        public void AddApplication(Application application)
        {
            _applicationDAO.AddApplication(application);
        }

        public void AddApplication(ApplicationFormBEAN application, int applicantId)
        {
            Application result = new Application();
            result.CourseName = application.CourseName;
            result.Firm = false;
            result.PersonalStatement = application.PersonalStatement;
            result.TeacherContactDetails = application.TeacherContacts;
            result.UniversityId = application.UniversityId;
            result.UniversityOffer = "P";
            result.ApplicantId = applicantId;
            _applicationDAO.AddApplication(result);
        }

        public void DeleteApplicationById(int id)
        {
            _applicationDAO.DeleteApplicationById(id);
        }

        public void EditApplication(Application application)
        {
            _applicationDAO.EditApplication(application);
        }
    }
}
