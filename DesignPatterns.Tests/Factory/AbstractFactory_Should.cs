using DesignPatterns.Factory.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Factory
{
    public class AbstractFactory_Should
    {
        /*
        Similar to Factory Method, but may erturn objects from a "family" of objects
        */

        [Fact]
        public void Create_BMW()
        {
            var factory = LoadFactory("BmwFactory");
            var economy = factory.CreateEconomyCar();
            var luxury = factory.CreateLuxuryCar();
            var sport = factory.CreateSportsCar();

            Assert.Equal("BMW 328i On", economy.TurnOn);
            Assert.Equal("BMW 740i On", luxury.TurnOn);
            Assert.Equal("BMW M3 On", sport.TurnOn);
        }

        [Fact]
        public void Create_Mini()
        {
            var factory = LoadFactory("MiniFactory");
            var economy = factory.CreateEconomyCar();
            var luxury = factory.CreateLuxuryCar();
            var sport = factory.CreateSportsCar();

            Assert.Equal("Base Mini On", economy.TurnOn);
            Assert.Equal("Mini with luxury package On", luxury.TurnOn);
            Assert.Equal("Mini with sports package On", sport.TurnOn);
        }

        [Fact]
        public void Create_NullAuto_For_Missing_Factory()
        {
            var factory = LoadFactory("FooFactory");
            var economy = factory.CreateEconomyCar();
            var luxury = factory.CreateLuxuryCar();
            var sport = factory.CreateSportsCar();

            Assert.Empty(economy.TurnOn);
            Assert.Empty(luxury.TurnOn);
            Assert.Empty(sport.TurnOn);
        }

        static IAutoFactory LoadFactory(string factoryName)
        {
            string typeName = $"DesignPatterns.Factory.AbstractFactory.{factoryName}"; // this should come from config setting
            return Assembly.GetAssembly(typeof(DesignPatternsAssembly))?.CreateInstance(typeName) as IAutoFactory ?? new NullFactory();
        }
    }
}
