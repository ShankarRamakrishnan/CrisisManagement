namespace WebApi
{
    using System;
    using Microsoft.Owin.Hosting;
    using Topshelf;

    public static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<Bootstraper>(s =>                        
                {
                    s.ConstructUsing(name => new Bootstraper());     
                    s.WhenStarted(tc => tc.Start());              
                    s.WhenStopped(tc => tc.Stop());               
                });
                x.RunAsLocalSystem();                            

                x.SetDescription("Web Api to transact with UI.");        
                x.SetDisplayName("CrisisManagement Web Api");                       
                x.SetServiceName("CrisisManagementWebApi");                       
            });
            Console.ReadKey();
        }
    }
}
