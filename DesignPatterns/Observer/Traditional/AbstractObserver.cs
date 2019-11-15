using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.Traditional
{
    public abstract class AbstractObserver
    {
        public abstract void Update();
    }

    public class GoogleObserver : AbstractObserver
    {
        public GoogleObserver(ILogger logger, StockTicker subject)
        {
            Logger = logger;
            DataSource = subject;
            subject.Register(this);
        }

        ILogger Logger { get; }
        StockTicker DataSource { get; }

        public override void Update()
        {
            if (DataSource.Stock?.Symbol == "GOOG")
                Logger.Log("GOOG", DataSource.Stock.Price);
        }
    }

    public class MicrosoftObserver : AbstractObserver
    {
        public MicrosoftObserver(ILogger logger, StockTicker subject)
        {
            Logger = logger;
            DataSource = subject;
            subject.Register(this);
        }

        ILogger Logger { get; }
        StockTicker DataSource { get; }

        public override void Update()
        {
            if (DataSource.Stock?.Symbol == "MSFT" && DataSource.Stock.Price > 10m)
                Logger.Log("MSFT", DataSource.Stock.Price); 
        }
    }
}
