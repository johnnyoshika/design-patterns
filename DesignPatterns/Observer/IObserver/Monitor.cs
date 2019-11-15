using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer.IObserver
{

    public class GoogleMonitor : IObserver<Stock>
    {
        public GoogleMonitor(ILogger logger)
        {
            Logger = logger;
        }

        ILogger Logger { get; }

        public void OnCompleted() => Logger.Complete(nameof(GoogleMonitor));

        public void OnError(Exception error) => Logger.Error(nameof(GoogleMonitor), error.Message);

        public void OnNext(Stock value)
        {
            if (value.Symbol == "GOOG")
                Logger.Log("GOOG", value.Price);
        }
    }

    public class MicrosoftMonitor : IObserver<Stock>
    {
        public MicrosoftMonitor(ILogger logger)
        {
            Logger = logger;
        }

        ILogger Logger { get; }

        public void OnCompleted() => Logger.Complete(nameof(MicrosoftMonitor));

        public void OnError(Exception error) => Logger.Error(nameof(MicrosoftMonitor), error.Message);

        public void OnNext(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10m)
                Logger.Log("MSFT", value.Price);
        }
    }
}
