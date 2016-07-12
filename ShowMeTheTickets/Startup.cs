using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowMeTheTickets.Startup))]
namespace ShowMeTheTickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
