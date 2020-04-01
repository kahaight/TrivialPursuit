using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrivialPursuitMVC.Startup))]
namespace TrivialPursuitMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
