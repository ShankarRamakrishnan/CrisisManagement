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
        public void Create(Crisis crisis)
        {
            Bus.Send("CrisisWorkflow", crisis);
        }

        [HttpGet]
        public void Status(Guid crisis)
        {
        }
    }
}
