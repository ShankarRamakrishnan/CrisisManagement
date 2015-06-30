namespace Chat
{
    using Microsoft.Owin.Cors;
    using Owin;

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}