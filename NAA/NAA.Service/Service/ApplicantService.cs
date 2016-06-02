using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Service.IService;
using NAA.Data.IDAO;
using NAA.Data.DAO;
using NAA.Data;


namespace NAA.Service.Service
{
    public class ApplicantService :IApplicantService
    {
        private IApplicantDAO _applicantDAO;
        public ApplicantService ()
        {
            _applicantDAO = new ApplicantDAO();
        }
        void AddApplicant(Applicant applicant)
        {

        }
    }
}
