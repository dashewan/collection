using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollectionBackGround.Startup))]
namespace CollectionBackGround
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
