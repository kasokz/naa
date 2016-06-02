using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAA.WebServices.Startup))]
namespace NAA.WebServices
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
