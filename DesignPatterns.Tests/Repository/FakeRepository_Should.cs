using DesignPatterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Repository
{
    public class FakeRepository_Should
    {
        [Fact]
        public void Add()
        {
            var repository = new FakeRepository<Employee>();
            repository.Add(new Employee { Id = 1 });
            var all = repository.FindAll().ToList();
            Assert.Single(all);
        }
    }
}
