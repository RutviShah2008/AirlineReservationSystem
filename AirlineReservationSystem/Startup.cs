using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineReservationSystem.Startup))]
namespace AirlineReservationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
