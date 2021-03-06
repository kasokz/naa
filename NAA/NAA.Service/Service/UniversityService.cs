﻿using NAA.Data;
using NAA.Data.DAO;
using NAA.Data.IDAO;
using NAA.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.Service
{
    public class UniversityService : IUniversityService
    {
        private IUniversityDAO _university;
        public UniversityService() { _university = new UniversityDAO(); }

        public IList<NAA.Data.University> GetUniversities()
        {
            return _university.GetUniversity();
        }

        public NAA.Data.University GetUniversityById(int id)
        {
            return _university.GetUniversityById(id);
        }

        public void EditUniversity(NAA.Data.University university)
        {
            _university.EditUniversity(university);
        }

        public void AddUniversity(NAA.Data.University university)
        {
            _university.AddUniversity(university);
        }

        public void DeleteUniversityById(int id)
        {
            _university.DeleteUniversityById(id);
        }
    }
}
