namespace WebApi.Controllers
{
    using System;
    using System.Web.Http;
    using Contracts;
    using NServiceBus;

    public class CrisisController : ApiController
    {
        IBus Bus { get; set; }

        public CrisisController(IBus bus)
        {
            this.Bus = bus;
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
        public void Status(Guid crisis)
        {
        }
    }
}
