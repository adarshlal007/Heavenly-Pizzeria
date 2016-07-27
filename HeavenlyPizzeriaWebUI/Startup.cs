using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeavenlyPizzeriaWebUI.Startup))]
namespace HeavenlyPizzeriaWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
