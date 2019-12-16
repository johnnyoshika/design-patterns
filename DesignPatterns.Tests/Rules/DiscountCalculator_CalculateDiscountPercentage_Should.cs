using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DesignPatterns.Rules;

namespace DesignPatterns.Tests.Rules
{
    public class DiscountCalculator_CalculateDiscountPercentage_Should
    {
        [Fact]
        public void Return_10_Percent_For_Birthday()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today,
                DateOfFirstPurchase = DateTime.Today.AddDays(-1)
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.10m, discount);
        }

        [Fact]
        public void Return_Percent_For_Senior()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today.AddYears(-65).AddDays(-5),
                DateOfFirstPurchase = DateTime.Today.AddDays(-1)
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.05m, discount);
        }

        [Fact]
        public void Return_10_Percent_For_Veteran()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today.AddDays(-5),
                IsVeteran = true,
                DateOfFirstPurchase = DateTime.Today.AddDays(-1)
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.10m, discount);
        }

        [Fact]
        public void Return_12_Percent_For_5_Year_Loyal_Customer()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today.AddDays(-5),
                DateOfFirstPurchase = DateTime.Today.AddYears(-5)
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.12m, discount);
        }

        [Fact]
        public void Return_22_Percent_For_5_Year_Loyal_Customer_On_Birthday()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today,
                DateOfFirstPurchase = DateTime.Today.AddYears(-5)
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.22m, discount);
        }

        [Fact]
        public void Return_15_Percent_For_New_Customer()
        {
            var customer = new Customer
            {
                DateOfBirth = DateTime.Today.AddDays(-5),
                DateOfFirstPurchase = null
            };

            var discount = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Assert.Equal(0.15m, discount);
        }
    }
}
