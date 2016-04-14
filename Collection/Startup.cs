using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Collection.Startup))]
namespace Collection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
