namespace Workflow
{
    using Contracts;
    using DatabaseLayer;
    using StructureMap.Configuration.DSL;

    public class WorkflowRegistry : Registry
    {
        public WorkflowRegistry()
        {
            For<IRepository<Crisis>>().Use<CrisisRepository>();
        }
    }
}
