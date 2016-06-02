using NAA.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Services;
using University.Services.IService;


namespace University.Services.Service
{
    class SheffieldHallamCourseService : IUniversityCourseService
    {
        public IList<CourseShortBEAN> GetAllCoursesShort()
        {
            throw new NotImplementedException();
        }

        public IList<CourseFullBEAN> GetAllCoursesFull()
        {
            throw new NotImplementedException();
        }
    }
}
