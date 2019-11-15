using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.EventsAndDelegates
{
    public class GoogleMonitor
    {
        public GoogleMonitor(ILogger logger, StockTicker st)
        {
            st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
            Logger = logger;
        }

        ILogger Logger { get; }

        void st_StockChange(object? sender, StockChangeEventArgs e) => CheckFilter(e.Stock);

        void CheckFilter(Stock value)
        {
            if (value.Symbol == "GOOG")
                Logger.Log("GOOG", value.Price);
        }
    }

    public class MicrosftMonitor
    {
        public MicrosftMonitor(ILogger logger, StockTicker st)
        {
            st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
            Logger = logger;
        }

        ILogger Logger { get; }

        void st_StockChange(object? sender, StockChangeEventArgs e) => CheckFilter(e.Stock);

        void CheckFilter(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10m)
                Logger.Log("MSFT", value.Price);
        }
    }
}
