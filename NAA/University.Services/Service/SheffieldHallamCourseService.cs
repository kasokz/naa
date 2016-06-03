using NAA.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Services;
using University.Services.IService;
using University.Services.Sheffield_Hallam;


namespace University.Services.Service
{
    class SheffieldHallamCourseService : IUniversityCourseService
    {
        private SHUWebService _proxy;

        public SheffieldHallamCourseService()
        {
            _proxy = new SHUWebService();
        }
        public IList<CourseShortBEAN> GetAllCoursesShort()
        {
            IList<CourseShortBEAN> _courseShortBEANs = new List<CourseShortBEAN>();
            foreach (var item in _proxy.GetAllNames())
            {
                _courseShortBEANs.Add(new CourseShortBEAN
                {
                    Id = item.CourseId,
                    Name = item.courseName
                });
            }
            return _courseShortBEANs;
        }

        public IList<CourseFullBEAN> GetAllCoursesFull()
        {
            IList<CourseFullBEAN> _courseFullBEANs = new List<CourseFullBEAN>();
            foreach (var item in _proxy.GetAllCourses())
            {
                _courseFullBEANs.Add(new CourseFullBEAN
                {
                    Id = item.CourseId,
                    Name = item.CourseName,
                    EntryCriteria = item.EntryCriteria,
                    Description = item.CourseDescription,
                    Notes = item.CourseContent
                });
            }
            return _courseFullBEANs;
        }
    }
}
