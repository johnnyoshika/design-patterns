using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.Traditional
{
    public abstract class AbstractSubject
    {
        List<AbstractObserver> _observers = new List<AbstractObserver>();

        public void Register(AbstractObserver observer) => _observers.Add(observer);
        public void Unregister(AbstractObserver observer) => _observers.Remove(observer);
        public void Notify() => _observers.ForEach(o => o.Update());
    }

    public class StockTicker : AbstractSubject
    {
        Stock? _stock;
        public Stock? Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                Notify();
            } 
        }

    }
}
