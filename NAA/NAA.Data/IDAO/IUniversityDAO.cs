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

        public University GetUniversityById();

        public void AddUniversity(University University);

        public void EditUniversity(University University);

        public void DeleteUniversityById(int id);
    }
}
