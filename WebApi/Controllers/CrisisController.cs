namespace WebApi.Controllers
{
    using System;
    using System.Web.Http;
    using Contracts;
    using DatabaseLayer;
    using NServiceBus;

    public class CrisisController : ApiController
    {
        IBus Bus { get; set; }
        private IRepository<Crisis> crisisRepo;

        public CrisisController(IBus bus, IRepository<Crisis> crisisRepo)
        {
            this.Bus = bus;
            this.crisisRepo = crisisRepo;
        }

        [HttpPost]
        public Guid Create(Crisis crisis)
        {
            crisis.Id = Guid.NewGuid();
            crisis.WhenHappend = DateTime.Now;
            Bus.Send("CrisisWorkflow", crisis);
            return crisis.Id;
        }

        [HttpGet]
        public Crisis Get(Guid id)
        {
            return crisisRepo.Get(id);
        }
    }
}
