using System;

namespace DesignPatterns.Rules
{
    public class Customer
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfFirstPurchase { get; set; }
        public bool IsVeteran { get; set; }
    }
}