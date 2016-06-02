using NAA.Services.IService;
using NAA.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Services.IService;

namespace University.Services.Service
{
    public class CourseServiceFactory
    {
        private static CourseServiceFactory instance = null;
        private IUniversityService _universityService;

        private CourseServiceFactory()
        {
            _universityService = new UniversityService();
        }

        public static CourseServiceFactory getInstance()
        {
            if (instance == null)
            {
                instance = new CourseServiceFactory();
            }
            return instance;
        }

        public IUniversityCourseService createCourseService(int universityId)
        {
            String universityName = _universityService.GetUniversityById(universityId).UniversityName;
            IUniversityCourseService result = null;
            switch (universityName)
            {
                case "Sheffield":
                    result = new SheffieldCourseService();
                    break;
                case "Sheffield Hallam":
                    result = new SheffieldHallamCourseService();
                    break;
            }
            return result;
        }
    }
}
