using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HFTestProject.Startup))]
namespace HFTestProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
