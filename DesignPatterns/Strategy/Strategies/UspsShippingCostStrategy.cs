using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy.Strategies
{
    public class UspsShippingCostStrategy : IShippingCostStrategy
    {
        public decimal Calculate(Order order) => 3;
    }
}
