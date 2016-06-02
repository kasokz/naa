using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.IService
{
    public interface IUniversityService
    {
        IList<NAA.Data.University> GetUniversities();

        NAA.Data.University GetUniversityById(int id);

        void EditUniversity(NAA.Data.University university);

        void AddUniversity(NAA.Data.University university);

        void DeleteUniversityById(int id);
    }
}
