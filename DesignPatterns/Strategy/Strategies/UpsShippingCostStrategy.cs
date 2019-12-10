using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy.Strategies
{
    public class UpsShippingCostStrategy : IShippingCostStrategy
    {
        public decimal Calculate(Order order) => 4.25m;
    }
}
