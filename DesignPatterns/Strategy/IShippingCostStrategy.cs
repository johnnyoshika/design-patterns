using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    public interface IShippingCostStrategy
    {
        decimal Calculate(Order order);
    }
}
