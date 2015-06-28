namespace Contracts
{
    using System;

    public class Crisis
    {
        public Guid Id { get; set; }
        public string Where { get; set; }
        public DateTime WhenHappend { get; set; }
        public string[] AffectedPeople { get; set; }
    }
}
