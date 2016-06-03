using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationDetailsBEAN
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Applicant ID")]
        public int ApplicantId { get; set; }
        [Display(Name = "Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "Course")]
        public string CourseName { get; set; }
        [Display(Name = "University")]
        public string UniversityName { get; set; }
        [Display(Name = "Personal Statement")]
        public string PersonalStatement { get; set; }
        [Display(Name = "University Offer")]
        public string UniversityOffer { get; set; }
        [Display(Name = "Firm")]
        public bool? Firm { get; set; }
        [Display(Name = "University Comment")]
        public string UniversityComment { get; set; }
        public ApplicationDetailsBEAN() { }
    }
}