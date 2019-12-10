using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DesignPatterns.TemplateMethod;

namespace DesignPatterns.Tests.TemplateMethod
{
    public class OrderShipment_Should
    {
        [Fact]
        public void Ship_Ups()
        {
            var logger = new Mock<ILogger>();
            var ups = new UpsOrderShipment();
            ups.Address = "123 Broadway";
            ups.Ship(logger.Object);

            logger.Verify(l => l.Log("UPS:[123 Broadway]"), Times.Once());
        }

        [Fact]
        public void Ship_FedEx()
        {
            var logger = new Mock<ILogger>();
            var ups = new FedExOrderShipment();
            ups.Address = "123 Broadway";
            ups.Ship(logger.Object);

            logger.Verify(l => l.Log("FedEx:[123 Broadway]"), Times.Once());
        }
    }
}
