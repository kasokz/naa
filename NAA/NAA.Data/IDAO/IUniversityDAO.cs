using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IUniversityDAO
    {
        IList<University> GetUniversity();

        University GetUniversityById(int id);

        void AddUniversity(University university);

        void EditUniversity(University university);

        void DeleteUniversityById(int id);
    }
}
