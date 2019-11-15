using DesignPatterns.Observer;
using DesignPatterns.Observer.IObserver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Observer.IObserver
{
    public class StockTicker_Should
    {
        [Fact]
        public void Notify_Observers_And_GoogleMonitor_Reacts()
        {
            var logger = new Mock<ILogger>();

            var st = new StockTicker();

            using (st.Subscribe(new GoogleMonitor(logger.Object)))
            using (st.Subscribe(new MicrosoftMonitor(logger.Object)))
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

            using (st.Subscribe(new GoogleMonitor(logger.Object)))
            using (st.Subscribe(new MicrosoftMonitor(logger.Object)))
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

        [Fact]
        public void Notify_Exceptions()
        {
            var logger = new Mock<ILogger>();

            var st = new StockTicker();

            using (st.Subscribe(new GoogleMonitor(logger.Object)))
            using (st.Subscribe(new MicrosoftMonitor(logger.Object)))
                st.Stock = new Stock { Symbol = null, Price = 200m };

            logger.Verify(l => l.Error(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            logger.Verify(l => l.Error(nameof(GoogleMonitor), It.IsAny<string>()), Times.Exactly(1));
            logger.Verify(l => l.Error(nameof(MicrosoftMonitor), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Notify_Completions()
        {
            var logger = new Mock<ILogger>();

            var st = new StockTicker();

            using (st.Subscribe(new GoogleMonitor(logger.Object)))
            using (st.Subscribe(new MicrosoftMonitor(logger.Object))) { }

            logger.Verify(l => l.Complete(It.IsAny<string>()), Times.Exactly(2));
            logger.Verify(l => l.Complete(nameof(GoogleMonitor)), Times.Exactly(1));
            logger.Verify(l => l.Complete(nameof(MicrosoftMonitor)), Times.Exactly(1));
        }
    }
}
