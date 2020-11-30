using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Smart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Configure formatters
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Formatters.Clear();
            config.Formatters.Add(jsonFormatter);

            var jsonSerializerSettings = jsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.Indented;
            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
