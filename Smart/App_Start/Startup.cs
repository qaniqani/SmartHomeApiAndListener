using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Smart.App_Start.Startup))]

namespace Smart.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();

            app.MapSignalR();
            //app.MapHubs("/signalr", new HubConfiguration());

            //app.MapSignalR("/mqtthub", new HubConfiguration());
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
