using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mallform.Startup))]
namespace mallform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
