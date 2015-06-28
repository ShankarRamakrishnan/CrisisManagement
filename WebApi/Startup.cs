
using Microsoft.Owin;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
    using System.Net.Http.Headers;
    using System.Web.Http;
    using NServiceBus;
    using Owin;
    using StructureMap;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default", "{controller}/{Id}", new { controller = "Crisis", customerID = RouteParameter.Optional });

            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new RouteDataMapping("extension", "json", new MediaTypeHeaderValue("application/json")));
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.StringEnumConverter());

            config.DependencyResolver = new StructureMapDependencyResolver(StructureMapBuilderConfig.GetStructureMapContainer());
            app.UseWebApi(config);
        }
    }
}
