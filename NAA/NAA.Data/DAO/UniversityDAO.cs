using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    class UniversityDAO
    {
        private NAAEntities _context;

        public UniversityDAO() {
            _context = new NAAEntities();
        }

        public IList<University> GetUniversity()
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            select university;
            return _universities.ToList<University>();
        }

        public University GetUniversityById();

        public void AddUniversity(University University);

        public void EditUniversity(University University);

        public void DeleteUniversityById(int id);
    }
}