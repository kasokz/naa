using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.IService
{
    public interface IUniversityService
    {
        IList<University> GetUniversities();

        University GetUniversityById(int id);

        void EditUniversity(University university);

        void AddUniversity(University university);

        void DeleteUniversityById(int id);
    }
}
