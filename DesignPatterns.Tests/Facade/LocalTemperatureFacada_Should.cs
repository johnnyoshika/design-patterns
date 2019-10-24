using DesignPatterns.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Facade
{
    public class LocalTemperatureFacada_Should
    {
        /*
        Facade provides a simple, purpose-built interface to a larger, more complex body of code.
        Common usages:
        - Wrap complex or multiple APIs
        - Cover up poorly written code to make it easier to consume
        */

        [Fact]
        public void Wrap_Complex_APIs_With_Simple_Interface()
        {
            var facade = new LocalTemperatureFacade();
            var localTemperature = facade.GetTemperature("83714");

            Assert.Equal("Boise", localTemperature.City);
            Assert.Equal("ID", localTemperature.State);
            Assert.Equal(72.4m, localTemperature.Temperature);
        }
    }
}
