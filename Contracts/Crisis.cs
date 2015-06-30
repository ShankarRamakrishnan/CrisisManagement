namespace Contracts
{
    using System;

    public class Crisis
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Location { get; set; }
        public DateTime WhenHappend { get; set; }
        public string[] AffectedPeople { get; set; }
        public string Description { get; set; }
    }
}
