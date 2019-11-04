using DesignPatterns.Mediator;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Mediator
{
    public class YvrCenter_Should
    {
        [Fact]
        public void Not_Warn_If_No_Intrusion()
        {
            var logger = new Mock<ILogger>();
            var atc = new YvrCenter(); // mediator

            var flight1 = new Airbus321("AC159", atc, logger.Object);
            var flight2 = new Boeing737("WS203", atc, logger.Object);
            var flight3 = new Embraer190("AC602", atc, logger.Object);

            flight1.Altitude = 30000;
            flight2.Altitude = 35000;
            flight3.Altitude = 32000;

            logger.Verify(l => l.Log(It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void Warn_Of_Intrusion()
        {
            var logger = new Mock<ILogger>();
            var atc = new YvrCenter(); // mediator

            var flight1 = new Airbus321("AC159", atc, logger.Object);
            var flight2 = new Boeing737("WS203", atc, logger.Object);
            var flight3 = new Embraer190("AC602", atc, logger.Object);

            flight1.Altitude = 30000;
            flight2.Altitude = 35000;
            flight3.Altitude = 34000;

            logger.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
            logger.Verify(l => l.Log($"{flight3.CallSign} intruding into {flight2.CallSign}'s airspace"), Times.Once());
        }
    }
}
