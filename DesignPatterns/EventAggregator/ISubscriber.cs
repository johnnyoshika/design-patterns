using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.EventAggregator
{
    public interface ISubscriber<T>
    {
        void OnEvent(T e);
    }
}
