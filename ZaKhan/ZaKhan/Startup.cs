using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZaKhan.Startup))]
namespace ZaKhan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
