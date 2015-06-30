namespace WebApi
{
    using System.Configuration;
    using Contracts;
    using DatabaseLayer;
    using Serilog;
    using StructureMap.Configuration.DSL;

    public class WebApiRegistry : Registry
    {
        public WebApiRegistry()
        {
            For<IRepository<Crisis>>().Use<CrisisRepository>();
            var logFolder = ConfigurationManager.AppSettings["LogFolder"] + @"\Log-{Date}.txt";
            var logger = new LoggerConfiguration().WriteTo.RollingFile(logFolder).CreateLogger();
            For<ILogger>().Use(x => logger);
        }
    }
}
