using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Car_Pool.Startup))]
namespace Car_Pool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
