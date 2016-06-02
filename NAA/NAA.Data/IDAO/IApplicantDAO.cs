using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IApplicantDAO
    {
        IList<Applicant> GetApplicants();

        Applicant GetApplicantById(int id);

        void AddApplicant(Applicant applicant);

        void DeleteApplicantById(int id);

        void EditApplicant(Applicant applicant);
    }
}
