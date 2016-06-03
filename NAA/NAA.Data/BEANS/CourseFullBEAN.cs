using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class CourseFullBEAN
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EntryCriteria { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public CourseFullBEAN() { }
    }
}
