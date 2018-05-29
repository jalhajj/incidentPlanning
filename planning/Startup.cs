using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(planning.Startup))]
namespace planning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
