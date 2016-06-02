using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Service.IService;
using NAA.Data.DAO;
using NAA.Data;

namespace NAA.Service.Service
{
    public class ApplicationService : IApplicationService
    {
        private ApplicationDAO _applicationDAO;

        public ApplicationService()
        {
            _applicationDAO = new ApplicationDAO();
        }

        public Application getApplicationById(int id)
        {
            return _applicationDAO.GetApplicationById(id);
        }

        public void AddApplication(Application application)
        {
            _applicationDAO.AddApplication(application);
        }

        public void DeleteApplicationById(int id)
        {
            _applicationDAO.DeleteApplicationById(id);
        }

        public void EditApplication(Application application)
        {
            _applicationDAO.EditApplication(application);
        }
    }
}
