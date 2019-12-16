using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Rules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer);
    }

    public class BirthdayDiscountRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer) =>
            customer.DateOfBirth.Month == DateTime.Today.Month && customer.DateOfBirth.Day == DateTime.Today.Day
                ? 0.10m
                : 0;
    }

    public class SeniorDiscountRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer) =>
            customer.DateOfBirth < DateTime.Now.AddYears(-65)
                ? 0.05m
                : 0m;
    }

    public class VeteralDiscountRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer) =>
            customer.IsVeteran ? 0.10m : 0m;
    }

    public class LoyalCustomerDiscountRule : IDiscountRule
    {
        public LoyalCustomerDiscountRule(int yearsAsCustomer, decimal discount)
        {
            YearsAsCustomer = yearsAsCustomer;
            Discount = discount;
        }

        int YearsAsCustomer { get; }
        decimal Discount { get; }

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.DateOfFirstPurchase.HasValue)
                if (customer.DateOfFirstPurchase.Value.AddYears(YearsAsCustomer) <= DateTime.Today)
                {
                    var birthdayRule = new BirthdayDiscountRule();
                    return Discount + birthdayRule.CalculateDiscount(customer);
                }

            return 0;
        }
    }

    public class FirstTimeCustomerDiscountRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer) =>
            !customer.DateOfFirstPurchase.HasValue
                ? 0.15m
                : 0;
    }
}
