using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QualityMeter.Web.Startup))]
namespace QualityMeter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
