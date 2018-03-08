using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreProjectUI.Startup))]
namespace StoreProjectUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
