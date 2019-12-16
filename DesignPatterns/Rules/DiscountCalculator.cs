using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Rules
{
    public class DiscountCalculator
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();

        public DiscountCalculator()
        {
            _rules.Add(new BirthdayDiscountRule());
            _rules.Add(new SeniorDiscountRule());
            _rules.Add(new VeteralDiscountRule());
            _rules.Add(new LoyalCustomerDiscountRule(1, 0.10m)); 
            _rules.Add(new LoyalCustomerDiscountRule(5, 0.12m)); 
            _rules.Add(new LoyalCustomerDiscountRule(10, 0.20m)); 
            _rules.Add(new FirstTimeCustomerDiscountRule());
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;
            foreach (var rule in _rules)
                discount = Math.Max(rule.CalculateDiscount(customer), discount);

            return discount;
        }
    }
}
