using NAA.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NAA.Data.IDAO
{
    public interface IApplicationDAO
    {
        IList<Application> GetApplications();

        Application GetApplicationById(int id);

        IList<Application> GetApplicationsByApplicantId(int id);

        ApplicationDetailsBEAN GetApplicationDetailsBEANByApplicantId(int id);

        IList<ApplicationListItemBEAN> GetApplicationListItemBEANsByApplicantId(int id);

        void AddApplication(Application application);

        void DeleteApplicationById(int id);

        void EditApplication(Application application);
    }
}
