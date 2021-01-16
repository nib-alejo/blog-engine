using System;

namespace Common.Entities
{
    public class Employee
    {
        public Employee()
        {
            Person = new Person();
            Role = new DomainDetail();
        }

        public Guid Id { get; set; }
        public Person Person { get; set; }
        public DomainDetail Role { get; set; }
    }
}
