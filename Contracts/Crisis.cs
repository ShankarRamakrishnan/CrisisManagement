namespace Contracts
{
    using System;
    using System.Collections.Generic;

    public class Crisis
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Location { get; set; }
        public DateTime WhenHappend { get; set; }
        public List<string> AffectedPeople { get; set; }
        public string Description { get; set; }
    }
}
