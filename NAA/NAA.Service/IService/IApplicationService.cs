using NAA.Data;
using NAA.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.IService
{
    public interface IApplicationService
    {
        IList<Application> getApplications();

        Application getApplicationById(int id);

        IList<Application> GetApplicationsByApplicantId(int id);

        IList<ApplicationBEAN> GetApplicationBEANsByApplicantId(int id);

        void AddApplication(Application application);

        void DeleteApplicationById(int id);

        void EditApplication(Application application);
    }
}
