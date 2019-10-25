using DesignPatterns.Factory.Simple;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Factory
{
    public class SimpleFactory_Should
    {
        [Fact]
        public void Create_BMW()
        {
            var factory = new AutoFactory();
            var auto = factory.CreateInstance("bmw");

            Assert.Equal("BMW On", auto.TurnOn);
            Assert.Equal("BMW Off", auto.TurnOff);
        }

        [Fact]
        public void Create_Mini()
        {
            var factory = new AutoFactory();
            var auto = factory.CreateInstance("mini");

            Assert.Equal("Mini On", auto.TurnOn);
            Assert.Equal("Mini Off", auto.TurnOff);
        }

        [Fact]
        public void Create_NullAuto_For_Missing_Auto()
        {
            var factory = new AutoFactory();
            var auto = factory.CreateInstance("foo");

            Assert.Empty(auto.TurnOn);
            Assert.Empty(auto.TurnOff);
        }
    }
}
