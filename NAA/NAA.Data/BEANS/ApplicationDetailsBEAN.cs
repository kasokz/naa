﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationDetailsBEAN
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public string CourseName { get; set; }
        public string UniversityName { get; set; }
        public string PersonalStatement { get; set; }
        public string UniversityOffer { get; set; }
        public bool? Firm { get; set; }
        public string UniversityComment { get; set; }
        public ApplicationDetailsBEAN() { }
    }
}