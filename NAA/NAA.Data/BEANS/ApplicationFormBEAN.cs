using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationFormBEAN
    {
        public int Id { get; set; }
        [Display(Name = "Applicant IDs")]
        public int ApplicantId { get; set; }
        [Display(Name = "University")]
        public int UniversityId { get; set; }
        [Display(Name = "Course")]
        public string CourseName { get; set; }
        [Display(Name = "Personal Statement")]
        public string PersonalStatement { get; set; }
        [Display(Name = "Teacher Contacts")]
        public string TeacherContacts { get; set; }

        public ApplicationFormBEAN() { }
    }
}
