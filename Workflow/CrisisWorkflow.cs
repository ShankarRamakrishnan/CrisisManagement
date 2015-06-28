namespace Workflow
{
    using Contracts;
    using DatabaseLayer;
    using NServiceBus;

    public class CrisisWorkflow : IHandleMessages<Crisis>
    {
        private readonly IRepository<Crisis> _repository;
        private IBus _bus;
        public CrisisWorkflow(IBus bus, IRepository<Crisis> repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(Crisis message)
        {
            _repository.Add(message);
        }
    }
}
