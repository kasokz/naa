using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationBEAN
    {
        public ApplicationBEAN() { }
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string CourseName { get; set; }
        public string UniversityName { get; set; }
        public string PersonalStatement { get; set; }
        public UniversityOffer UniversityOffer { get; set; }
        public bool Firm { get; set; }
    }

    public enum UniversityOffer
    {
        R = "Reject",
        P = "Pending",
        C = "Conditional",
        U = "Unconditional"
    };
}