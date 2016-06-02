using NAA.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.IService
{
    public interface IUniversityCourseService
    {
        IList<CourseShortBEAN> GetAllCoursesShort();

        IList<CourseFullBEAN> GetAllCoursesFull();
    }
}
