using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDulsa.Startup))]
namespace WebDulsa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
