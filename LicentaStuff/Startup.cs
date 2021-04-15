using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LicentaStuff.Startup))]
namespace LicentaStuff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
