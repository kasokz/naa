using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.BEANS;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        private NAAEntities _context;

        public ApplicationDAO()
        {
            _context = new NAAEntities();
        }

        public IList<Application> GetApplications()
        {
            IQueryable<Application> allApplications;
            allApplications = from applications
                            in _context.Application
                            select applications;
            return allApplications.ToList<Application>();
        }

        public Application GetApplicationById(int id)
        {
            IQueryable<Application> applicationResult;
            applicationResult = from application
                                in _context.Application
                                where application.Id == id
                                select application;
            return applicationResult.First();
        }

        public IList<Application> GetApplicationsByApplicantId(int id)
        {
            IQueryable<Application> applicationResult;
            applicationResult = from application
                                in _context.Application
                                where application.ApplicantId == id
                                select application;
            return applicationResult.ToList();
        }

        public ApplicationDetailsBEAN GetApplicationDetailsBEANById(int id)
        {
            IQueryable<ApplicationDetailsBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from applicant in _context.Applicant
                                from university in _context.University
                                where applicant.Id == application.ApplicantId
                                where application.Id == id
                                where university.UniversityId == application.UniversityId
                                select new ApplicationDetailsBEAN
                                {
                                    Id = application.Id,
                                    ApplicantName = applicant.ApplicantName,
                                    CourseName = application.CourseName,
                                    UniversityName = university.UniversityName,
                                    PersonalStatement = application.PersonalStatement,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.First();
        }

        public IList<ApplicationListItemBEAN> GetApplicationListItemBEANsByApplicantId(int id)
        {
            IQueryable<ApplicationListItemBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from university in _context.University
                                where application.ApplicantId == id
                                where university.UniversityId == application.UniversityId
                                select new ApplicationListItemBEAN
                                {
                                    Id = application.Id,
                                    UniversityName = university.UniversityName,
                                    CourseName = application.CourseName,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.ToList();
        }

        public void AddApplication(Application application)
        {
            _context.Application.Add(application);
            _context.SaveChanges();
        }

        public void DeleteApplicationById(int id)
        {
            _context.Application.Remove(GetApplicationById(id));
            _context.SaveChanges();
        }

        public void EditApplication(Application application)
        {
            Application currentApplication = (from currApplication
                                             in _context.Application
                                             where currApplication.Id == application.Id
                                             select currApplication).First();
            currentApplication.PersonalStatement = application.PersonalStatement;
            currentApplication.TeacherContactDetails = application.TeacherContactDetails;
            currentApplication.TeacherReference = application.TeacherReference;
            currentApplication.UniversityId = application.UniversityId;
            currentApplication.UniversityOffer = application.UniversityOffer;
            currentApplication.Firm = application.Firm;
            currentApplication.ApplicantId = application.ApplicantId;
            currentApplication.CourseName = application.CourseName;
            _context.SaveChanges();
        }
    }
}
