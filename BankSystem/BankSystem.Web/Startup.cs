using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankSystem.Web.Startup))]
namespace BankSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
