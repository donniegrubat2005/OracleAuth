using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OracleAuth.Startup))]
namespace OracleAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
