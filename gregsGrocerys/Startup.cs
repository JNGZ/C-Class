using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gregsGrocerys.Startup))]
namespace gregsGrocerys
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }

    }
}
