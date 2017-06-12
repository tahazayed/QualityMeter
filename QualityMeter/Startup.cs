using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QualityMeter.Startup))]
namespace QualityMeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
