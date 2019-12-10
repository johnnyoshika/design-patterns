using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    // This class is called a 'Context' within the Strategy pattern concept
    public class ShippingCostCalculatorService
    {
        public ShippingCostCalculatorService(IShippingCostStrategy strategy) => Strategy = strategy;
        IShippingCostStrategy Strategy { get; }

        public decimal CalculateShippingCost(Order order) => Strategy.Calculate(order);
    }
}
