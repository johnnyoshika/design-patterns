using DesignPatterns.Observer;
using DesignPatterns.Observer.Traditional;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Observer.Traditional
{
    /*
    This traditional approach has problems:
    - If there are multiple subjects, they need to be registered with each observer
    - What if multiple properties are involved?
    - Disposing subjects can be a problem because observers hold references to them
    - Unexpected updates when there are lots of observers
    - Hard to observe different properties separately
    */ 

    public class StockTicker_Should
    {
        [Fact]
        public void Notify_Observers_And_GoogleObserver_Updates()
        {
            var logger = new Mock<ILogger>();

            var subject = new StockTicker();
            new GoogleObserver(logger.Object, subject);
            new MicrosoftObserver(logger.Object, subject);

            new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 200m },
                new Stock { Symbol = "WORK", Price = 100m },
                new Stock { Symbol = "GOOG", Price = 300m },
                new Stock { Symbol = "MSFT", Price = 9m },
                new Stock { Symbol = "XOM", Price = 50m }
            }.ForEach(s => subject.Stock = s);

            logger.Verify(l => l.Log(It.IsAny<string>(), It.IsAny<decimal>()), Times.Once());
            logger.Verify(l => l.Log("GOOG", 300m), Times.Once());
        }

        [Fact]
        public void Notify_Observers_And_MicrosftObserver_Updates()
        {
            var logger = new Mock<ILogger>();

            var subject = new StockTicker();
            new GoogleObserver(logger.Object, subject);
            new MicrosoftObserver(logger.Object, subject);

            new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 200m },
                new Stock { Symbol = "WORK", Price = 100m },
                new Stock { Symbol = "MSFT", Price = 11m },
                new Stock { Symbol = "XOM", Price = 50m }
            }.ForEach(s => subject.Stock = s);

            logger.Verify(l => l.Log(It.IsAny<string>(), It.IsAny<decimal>()), Times.Once());
            logger.Verify(l => l.Log("MSFT", 11m), Times.Once());
        }
    }
}
