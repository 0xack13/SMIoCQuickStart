using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(customProfile.Startup))]
namespace customProfile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
