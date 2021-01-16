using System;

namespace Common.Entities
{
    public class DomainDetail
    {
        public Guid Id { get; set; }
        public Domain Domain { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
