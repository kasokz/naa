using NAA.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public class UniversityDAO : NAADAO, IUniversityDAO
    {
        public IList<University> GetUniversity()
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            select university;
            return _universities.ToList<University>();
        }

        public University GetUniversityById(int id)
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            where university.UniversityId == id
                            select university;
            return _universities.First();
        }

        public void AddUniversity(University university)
        {
            _context.University.Add(university);
            _context.SaveChanges();
        }

        public void EditUniversity(University university)
        {
            University currentUni = (from uni
                            in _context.University
                                     where uni.UniversityId == university.UniversityId
                                     select uni).First();
            currentUni.UniversityId = university.UniversityId;
            currentUni.UniversityName = university.UniversityName;
            _context.SaveChanges();
        }

        public void DeleteUniversityById(int id)
        {
            _context.University.Remove(GetUniversityById(id));
            _context.SaveChanges();
        }
    }
}