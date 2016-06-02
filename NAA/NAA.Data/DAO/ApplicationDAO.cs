using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.BEANS;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : NAADAO, IApplicationDAO
    {
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
            IQueryable<Application> _applicationResult;
            _applicationResult = from application
                                in _context.Application
                                where application.ApplicantId == id
                                select application;
            return _applicationResult.ToList();
        }

        public IList<ApplicationBEAN> GetApplicationsByUniversityName(string name)
        {
            IQueryable<ApplicationBEAN> _applicationBEANs;
            _applicationBEANs = from application in _context.Application
                                from applicant in _context.Applicant
                                from university in _context.University
                                where university.UniversityName == name
                                where application.UniversityId == university.UniversityId
                                select new ApplicationBEAN
                                {
                                    Id = application.Id,
                                    ApplicantName = applicant.ApplicantName,
                                    ApplicantAddress = applicant.ApplicantAddress,
                                    ApplicantPhone = applicant.Phone,
                                    ApplicantEmail = applicant.Email,
                                    CourseName = application.CourseName,
                                    PersonalStatement = application.PersonalStatement,
                                    TeacherReference = application.TeacherReference,
                                    TeacherContactDetails = application.TeacherContactDetails,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _applicationBEANs.ToList();
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
            try
            {
                _context.Application.Add(application);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
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
