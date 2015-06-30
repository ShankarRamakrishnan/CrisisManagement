namespace Workflow
{
    using Common;
    using Contracts;
    using DatabaseLayer;
    using NServiceBus;
    using Serilog;

    public class CrisisWorkflow : IHandleMessages<Crisis>
    {
        private readonly IRepository<Crisis> _repository;
        private readonly ILogger _logger;
        private IBus _bus;
        private readonly Mail _email;
        public CrisisWorkflow(IBus bus, IRepository<Crisis> repository, ILogger logger)
        {
            _bus = bus;
            _repository = repository;
            _logger = logger;
            _email = new Mail();
        }

        public void Handle(Crisis message)
        {
            _logger.Information("Adding Crisis id {@id} to Database.", message.Id);
            _repository.Add(message);
            _email.SendEmail("snowshan@live.com", "Crisis - Immediate Action Required !", 
                "Dear Shankar, \n\n" +
                "There is a Crisis at your office. \n" +
                "Please contact your office to understand your part to mitigate it.\n\n" +
                "Regards, \n" +
                "Crisis Management Team.");
        }
    }
}
