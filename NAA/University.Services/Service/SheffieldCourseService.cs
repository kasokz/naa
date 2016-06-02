using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Services.IService;
using University.Services;
using University.Services.Sheffield;
using NAA.Data;
using NAA.Data.BEANS;

namespace University.Services.Service
{
    public class SheffieldCourseService : IUniversityCourseService
    {
        private SheffieldUniCourses _proxy;

        public SheffieldCourseService()
        {
            _proxy = new SheffieldUniCourses();
        }

        public IList<CourseShortBEAN> GetAllCoursesShort()
        {
            IList<CourseShortBEAN> _courseShortBEANs = new List<CourseShortBEAN>();
            foreach (var item in _proxy.GetCoursesShortDetails())
            {
                _courseShortBEANs.Add(new CourseShortBEAN
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return _courseShortBEANs;
        }

        public IList<CourseFullBEAN> GetAllCoursesFull()
        {
            throw new NotImplementedException();
        }
    }
}
