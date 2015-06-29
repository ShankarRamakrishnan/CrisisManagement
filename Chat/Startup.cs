namespace Chat
{
    using System.Web.Http;
    using Microsoft.Owin.Cors;
    using Owin;

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute("Default", "{controller}/{Id}",
            //    new {controller = "Crisis", customerID = RouteParameter.Optional});

            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(
            //    new RouteDataMapping("extension", "json", new MediaTypeHeaderValue("application/json")));
            //config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
            //    new Newtonsoft.Json.Converters.StringEnumConverter());
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}