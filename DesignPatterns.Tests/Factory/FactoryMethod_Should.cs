using DesignPatterns.Factory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Factory
{
    public class FactoryMethod_Should
    {
        /*
        Advantage of Factory Method over Simple Factory:
        - Eliminate references to concrete factories (in addition to concrete objects in Simple Factory)
        - Factories can be inherited
        - Rules for object initialization is centralized
        */

        [Fact]
        public void Create_BMW()
        {
            var factory = LoadFactory("BmwFactory");
            var auto = factory.CreateAuto();

            Assert.Equal("BMW On", auto.TurnOn);
            Assert.Equal("BMW Off", auto.TurnOff);
        }

        [Fact]
        public void Create_Mini()
        {
            var factory = LoadFactory("MiniFactory");
            var auto = factory.CreateAuto();

            Assert.Equal("Mini On", auto.TurnOn);
            Assert.Equal("Mini Off", auto.TurnOff);
        }

        [Fact]
        public void Create_NullAuto_For_Missing_Factory()
        {
            var factory = LoadFactory("FooFactory");
            var auto = factory.CreateAuto();

            Assert.Empty(auto.TurnOn);
            Assert.Empty(auto.TurnOff);
        }

        static IAutoFactory LoadFactory(string factoryName)
        {
            string typeName = $"DesignPatterns.Factory.FactoryMethod.{factoryName}"; // this should come from config setting
            return Assembly.GetAssembly(typeof(DesignPatternsAssembly))?.CreateInstance(typeName) as IAutoFactory ?? new NullFactory();
        }
    }
}
