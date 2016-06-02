using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class ApplicantDAO : NAADAO, IApplicantDAO
    {

        public IList<Applicant> GetApplicants()
        {
            IQueryable<Applicant> allApplicants = from applicants
                                                  in _context.Applicant
                                                  select applicants;
            return allApplicants.ToList();
        }

        public Applicant GetApplicantById(int id)
        {
            IQueryable<Applicant> applicantResult = from applicant
                                                    in _context.Applicant
                                                    where applicant.Id == id
                                                    select applicant;
            return applicantResult.First();
        }

        public void AddApplicant(Applicant applicant)
        {
            _context.Applicant.Add(applicant);
            _context.SaveChanges();
        }

        public void DeleteApplicantById(int id)
        {
            _context.Applicant.Remove(GetApplicantById(id));
            _context.SaveChanges();
        }

        public void EditApplicant(Applicant applicant)
        {
            Applicant currentApplicant = (from currApplicant
                                             in _context.Applicant
                                          where currApplicant.Id == applicant.Id
                                          select currApplicant).First();
            currentApplicant.ApplicantAddress = applicant.ApplicantAddress;
            currentApplicant.ApplicantName = applicant.ApplicantName;
            currentApplicant.Email = applicant.Email;
            currentApplicant.Phone = applicant.Phone;
            _context.SaveChanges();
        }
    }
}
