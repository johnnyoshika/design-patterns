using DesignPatterns.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.UnitOfWork
{
    public class InMemoryUnitOfWork_Should
    {
        [Fact]
        public void Commit()
        {
            var uow = new InMemoryUnitOfWork();
            var employees = uow.Employees;
            employees.First().Name = "Bob";
            employees.Last().Name = "Kim";

            Assert.False(uow.Committed);

            uow.Commit();

            Assert.True(uow.Committed);
        }
    }
}
