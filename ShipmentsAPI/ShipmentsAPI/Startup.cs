using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using ShipmentsAPI;

[assembly: OwinStartup(typeof(Startup))]
namespace ShipmentsAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new System.Web.Http.HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}