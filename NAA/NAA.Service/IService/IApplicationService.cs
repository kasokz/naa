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
        IList<Application> GetApplications();

        Application GetApplicationById(int id);

        IList<Application> GetApplicationsByApplicantId(int id);

        IList<ApplicationBEAN> GetApplicationsByUniversityName(string name);

        ApplicationDetailsBEAN GetApplicationDetailsBEANById(int id);

        IList<ApplicationListItemBEAN> GetApplicationListItemBEANSByApplicantId(int id);

        void AddApplication(Application application);

        void AddApplication(ApplicationFormBEAN application);

        void DeleteApplicationById(int id);

        void EditApplication(Application application);

        void FirmApplication(int id);
    }
}
