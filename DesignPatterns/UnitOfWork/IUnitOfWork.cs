using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEnumerable<Employee> Employees { get; }
        IEnumerable<TimeCard> TimeCards { get; }
        void Commit();
    }
}
