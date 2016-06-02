using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Service.IService
{
    public interface IApplicantService
    {
        void AddApplicant(Applicant applicant);
        void DeleteApplicant(int id);
        void EditApplicant(int id);
        void GetApplicant(int id);

    }
}
