using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.EventsAndDelegates
{
    public class StockTicker
    {
        Stock? _stock;
        public Stock? Stock
        {
            get => _stock;
            set
            {
                _stock = value ?? throw new ArgumentNullException();
                OnStockChange(new StockChangeEventArgs(_stock));
            }
        }

        // we can add additional event handlers here...

        public event EventHandler<StockChangeEventArgs>?  StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e) => StockChange?.Invoke(this, e);
        /*
        StockChange?.Invoke(this, e); is equivalent to:
        
        if (StockChange != null)
            StockChange(this, e);
        */
    }

    public class StockChangeEventArgs
    {
        public StockChangeEventArgs(Stock stock)
        {
            Stock = stock;
        }

        public Stock Stock { get; }
    }
}
