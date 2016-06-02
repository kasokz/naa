using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Services.IService;
using NAA.Data.IDAO;
using NAA.Data.DAO;
using NAA.Data;


namespace NAA.Services.Service
{
    public class ApplicantService :IApplicantService
    {
        private IApplicantDAO _applicantDAO;
        public ApplicantService ()
        {
            _applicantDAO = new ApplicantDAO();
        }
        public void AddApplicant(Applicant applicant)
        {
            _applicantDAO.AddApplicant(applicant);
        }
        public void DeleteApplicantById(int id)
        {
            _applicantDAO.DeleteApplicantById(id);
        }
        public void EditApplicant(Applicant applicant)
        {
            _applicantDAO.EditApplicant(applicant);
        }
        public Applicant GetApplicantById(int id)
        {
            return _applicantDAO.GetApplicantById(id);
        }

    }
}
