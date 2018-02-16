using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityAssignment.Startup))]
namespace IdentityAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
