using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gadi.Startup))]
namespace Gadi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
