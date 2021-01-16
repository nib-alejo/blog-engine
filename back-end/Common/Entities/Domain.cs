using System;

namespace Common.Entities
{
    public class Domain
    {
        public Domain() { }

        public Guid Id { get; set; }
        public string Description { get; set; }

        //Additional
        public DomainDetail[] DomainDetailList { get; set; }
    }
}
