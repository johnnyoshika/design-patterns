using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }

    public class Person : IAsset
    {
        public List<IAsset> Assets { get; set; } = new List<IAsset>();

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
                asset.Accept(visitor);
        }
    }

    public class Loan : IAsset
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class BankAccount : IAsset
    {
        public int Amount { get; set; }
        public decimal InterestRate { get; set; }

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class RealEstate : IAsset
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
