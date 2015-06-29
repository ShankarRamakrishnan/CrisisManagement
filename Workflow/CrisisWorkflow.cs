namespace Workflow
{
    using Common;
    using Contracts;
    using DatabaseLayer;
    using NServiceBus;

    public class CrisisWorkflow : IHandleMessages<Crisis>
    {
        private readonly IRepository<Crisis> _repository;
        private IBus _bus;
        private readonly Mail _email;
        public CrisisWorkflow(IBus bus, IRepository<Crisis> repository)
        {
            _bus = bus;
            _repository = repository;
            _email = new Mail();
        }

        public void Handle(Crisis message)
        {
            _repository.Add(message);
            _email.SendEmail("shankarr.remya@gmail.com", "snowshan@live.com", "Crisis - Immediate Action Required !", 
                "Dear Shankar, \n\n" +
                "There is a Crisis at your office. \n" +
                "Please contact your office to understand your part to mitigate it.\n\n" +
                "Regards, \n" +
                "Crisis Management Team.");
        }
    }
}
