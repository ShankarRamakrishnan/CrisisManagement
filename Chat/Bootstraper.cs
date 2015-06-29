namespace Chat
{
    using Microsoft.Owin.Hosting;

    internal class Bootstraper
    {
        public void Start()
        {
            const string uri = "http://localhost:12345/";
            WebApp.Start<Startup>(uri);
        }
        public void Stop()
        {

        }
    }
}