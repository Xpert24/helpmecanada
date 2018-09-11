using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpMeCanada.Startup))]
namespace HelpMeCanada
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

