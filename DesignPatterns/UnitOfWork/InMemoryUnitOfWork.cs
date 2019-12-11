using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.UnitOfWork
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IEnumerable<Employee> Employees => new List<Employee>
        {
            new Employee { Id = 1 },
            new Employee { Id = 2 }
        };

        public IEnumerable<TimeCard> TimeCards => new List<TimeCard>
        {
            new TimeCard { Id = 1 },
            new TimeCard { Id = 2 }
        };

        public bool Committed { get; private set; } = false;
        public void Commit() => Committed = true;
    }
}
