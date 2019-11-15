using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer
{
    public interface ILogger
    {
        void Log(string symbol, decimal price);
        void Error(string monitorName, string message);
        void Complete(string monitorName);
    }
}
