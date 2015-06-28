namespace Workflow
{
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

                x.SetDescription("NServicebus Endpoint to Handle the Crisis Workflow.");        
                x.SetDisplayName("CrisisManagement NSB Endpoint");                       
                x.SetServiceName("CrisisManagementNSBEndpoint");                       
            });    
        }
    }
}
