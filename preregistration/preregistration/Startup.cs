using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(preregistration.Startup))]
namespace preregistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
