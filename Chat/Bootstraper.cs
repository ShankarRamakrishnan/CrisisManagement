namespace Chat
{
    using System.Configuration;
    using Microsoft.Owin.Hosting;

    internal class Bootstraper
    {
        public void Start()
        {
            string uri = ConfigurationManager.AppSettings["Uri"];
            WebApp.Start<Startup>(uri);
        }
        public void Stop()
        {

        }
    }
}