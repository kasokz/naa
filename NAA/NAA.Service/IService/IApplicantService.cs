using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IService
{
    public interface IApplicantService
    {
        void AddApplicant(Applicant applicant);
        void DeleteApplicantById(int id);
        void EditApplicant(Applicant applicant);
        Applicant GetApplicantById(int id);
        IList<Applicant> GetApplicants();
        bool NoApplicants();
    }
}
