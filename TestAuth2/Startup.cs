using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAuth2.Startup))]
namespace TestAuth2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
