using DesignPatterns.Strategy;
using DesignPatterns.Strategy.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Strategy
{
    // Note: Using dependency injection in ASP.NET MVC is essentially using the strategy pattern.
    public class ShippingCostCalculatorService_Calculate_Should
    {
        [Fact]
        public void Return_5_When_Shipping_Via_FedEx()
        {
            var service = new ShippingCostCalculatorService(
                new FedExShippingCostStrategy());

            var cost = service.CalculateShippingCost(new Order());

            Assert.Equal(5, cost);
        }

        [Fact]
        public void Return_425_When_Shipping_Via_Ups()
        {
            var service = new ShippingCostCalculatorService(
                new UpsShippingCostStrategy());

            var cost = service.CalculateShippingCost(new Order());

            Assert.Equal(4.25m, cost);
        }

        [Fact]
        public void Return_3_When_Shipping_Via_Usps()
        {
            var service = new ShippingCostCalculatorService(
                new UspsShippingCostStrategy());

            var cost = service.CalculateShippingCost(new Order());

            Assert.Equal(3, cost);
        }
    }
}
