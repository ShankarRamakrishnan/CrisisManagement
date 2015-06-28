namespace Workflow
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using StructureMap;
    using StructureMap.Graph;

    public class StructureMapBuilderConfig
    {
        private static Container _container;
        public static Container GetStructureMapContainer()
        {
            return _container ?? (_container = new Container(Scan));
        }

        private static void Scan(ConfigurationExpression configExpression)
        {
            configExpression.Scan(ScanAssemblies);
        }

        private static void ScanAssemblies(IAssemblyScanner scanner)
        {
            var assebliesToBeScanned = ConfigurationManager.AppSettings["AssembliesToBeScanned"];
            List<string> assemblies = null;
            if (assebliesToBeScanned != null)
            {
                assemblies = assebliesToBeScanned.Split(';').ToList();
            }

            if (assemblies != null)
            {
                assemblies.ForEach(scanner.Assembly);
            }

            scanner.WithDefaultConventions();
            scanner.TheCallingAssembly();
            scanner.LookForRegistries();
        }
    }
}
