namespace Workflow
{
    using System.Configuration;
    using NServiceBus;
    using NServiceBus.Features;

    public class Bootstraper
    {
        public void Start()
        {
             var  assemblies = AllAssemblies.Except("IKVM.OpenJDK.Core.dll");

            var config = new BusConfiguration();
            config.UsePersistence<InMemoryPersistence>();
            config.Conventions().DefiningMessagesAs(x => (x.Namespace != null && x.Namespace.Contains("Contracts")));
            config.EndpointName(ConfigurationManager.AppSettings["EndpointName"]);
            config.EnableDurableMessages();
            config.UseSerialization<XmlSerializer>();
            config.UseTransport<RabbitMQTransport>().DisableCallbackReceiver();
            config.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(StructureMapBuilderConfig.GetStructureMapContainer()));
            config.DisableFeature<SecondLevelRetries>();
            config.DisableFeature<StorageDrivenPublishing>();
            config.DisableFeature<TimeoutManager>();
            config.AssembliesToScan(assemblies);
            var buz = Bus.Create(config);
            buz.Start();



        }

        public void Stop()
        {
            
        }
    }
}
