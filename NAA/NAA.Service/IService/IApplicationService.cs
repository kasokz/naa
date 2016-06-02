using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NAA.Service.IService
{
    public interface IApplicationService
    {
        Application getApplicationById(int id);

        void AddApplication(Application application);

        void DeleteApplicationById(int id);

        void EditApplication(Application application);
    }
}
