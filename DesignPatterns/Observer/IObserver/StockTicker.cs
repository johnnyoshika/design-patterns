using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.IObserver
{
    public class StockTicker : IObservable<Stock>
    {
        List<IObserver<Stock>> _observers = new List<IObserver<Stock>>();

        Stock? _stock;
        public Stock? Stock
        {
            get => _stock;
            set
            {
                _stock = value ?? throw new ArgumentNullException();
                Notify(_stock);
            }
        }

        void Notify(Stock s) => _observers.ForEach(o =>
        {
            if (s.Symbol == null || s.Price < 0)
                o.OnError(new Exception("Bad Stock Data"));
            else
                o.OnNext(s);
        });

        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        class Unsubscriber : IDisposable
        {
            public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
            {
                Observers = observers;
                Observer = observer;
            }

            List<IObserver<Stock>> Observers { get; }
            IObserver<Stock> Observer { get; }

            public void Dispose()
            {
                if (Observer != null && Observers.Contains(Observer))
                {
                    Observer.OnCompleted();
                    Observers.Remove(Observer);
                }
            }
        }
    }
}
