using DesignPatterns.Observer;
using DesignPatterns.Observer.EventsAndDelegates;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Observer.EventsAndDelegates
{
    public class StockTicker_Should
    {
        /*
        Similar to the Traditional approach, disposing subjects is a problem because observers hold references to them
        */

        [Fact]
        public void Notify_Observers_And_GoogleMonitor_Reacts()
        {
            var logger = new Mock<ILogger>();

            var st = new StockTicker();

            new GoogleMonitor(logger.Object, st);
            new MicrosftMonitor(logger.Object, st);

            new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 200m },
                new Stock { Symbol = "WORK", Price = 100m },
                new Stock { Symbol = "GOOG", Price = 300m },
                new Stock { Symbol = "MSFT", Price = 9m },
                new Stock { Symbol = "XOM", Price = 50m }
            }.ForEach(s => st.Stock = s);

            logger.Verify(l => l.Log(It.IsAny<string>(), It.IsAny<decimal>()), Times.Once());
            logger.Verify(l => l.Log("GOOG", 300m), Times.Once());
        }

        [Fact]
        public void Notify_Observers_And_MicrosoftMonitor_Reacts()
        {
            var logger = new Mock<ILogger>();

            var st = new StockTicker();

            new GoogleMonitor(logger.Object, st);
            new MicrosftMonitor(logger.Object, st);

            new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 200m },
                new Stock { Symbol = "WORK", Price = 100m },
                new Stock { Symbol = "MSFT", Price = 11m },
                new Stock { Symbol = "XOM", Price = 50m }
            }.ForEach(s => st.Stock = s);

            logger.Verify(l => l.Log(It.IsAny<string>(), It.IsAny<decimal>()), Times.Once());
            logger.Verify(l => l.Log("MSFT", 11m), Times.Once());
        }
    }
}
