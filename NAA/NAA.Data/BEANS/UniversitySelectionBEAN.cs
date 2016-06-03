using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class UniversitySelectionBEAN
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        [Display(Name="University")]
        public int UniversityId { get; set; }

        public UniversitySelectionBEAN() { }
    }
}
