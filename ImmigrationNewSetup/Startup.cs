using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImmigrationNewSetup.Startup))]
namespace ImmigrationNewSetup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
