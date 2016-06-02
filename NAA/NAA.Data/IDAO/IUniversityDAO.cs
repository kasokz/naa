using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    interface IUniversityDAO
    {
        public IList<University> GetUniversity();

        public University GetUniversityById(int id);

        public void AddUniversity(University university);

        public void EditUniversity(University university);

        public void DeleteUniversityById(int id);
    }
}
