using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portafolio_.Startup))]
namespace Portafolio_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
