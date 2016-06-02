using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationFormBEAN
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public int UniversityId { get; set; }

        public string CourseName { get; set; }

        public string PersonalStatement { get; set; }

        public string TeacherContacts { get; set; }

        public ApplicationFormBEAN() { }
    }
}
