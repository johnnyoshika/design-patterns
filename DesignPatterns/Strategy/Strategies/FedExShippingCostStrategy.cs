using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy.Strategies
{
    public class FedExShippingCostStrategy : IShippingCostStrategy
    {
        public decimal Calculate(Order order) => 5;
    }
}
