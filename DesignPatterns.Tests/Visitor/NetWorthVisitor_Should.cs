using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Visitor
{
    public class NetWorthVisitor_Should
    {
        [Fact]
        public void Calculate_Net_Worth()
        {
            var person = new Person();
            person.Assets.Add(new BankAccount { Amount = 1000, InterestRate = 0.05m });
            person.Assets.Add(new BankAccount { Amount = 2000, InterestRate = 0.1m });
            person.Assets.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 2000 });
            person.Assets.Add(new Loan { Owed = 40000, MonthlyPayment = 100 });

            var netWorthVisitor = new NetWorthVisitor();
            person.Accept(netWorthVisitor);

            Assert.Equal(42000, netWorthVisitor.Total);
        }
    }
}
