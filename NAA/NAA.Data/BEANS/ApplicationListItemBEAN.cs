using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationListItemBEAN
    {
        public int Id { get; set; }
        [Display(Name="University")]
        public string UniversityName { get; set; }
        [Display(Name = "Course")]
        public string CourseName { get; set; }
        [Display(Name = "University Offer")]
        public string UniversityOffer { get; set; }
        [Display(Name = "Firm")]
        public bool? Firm { get; set; }
        public ApplicationListItemBEAN() { }
    }
}
