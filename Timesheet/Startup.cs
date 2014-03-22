using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Timesheet.Startup))]
namespace Timesheet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
