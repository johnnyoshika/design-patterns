using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit(RealEstate realEstate);
        void Visit(BankAccount bankAccount);
        void Visit(Loan loan);
    }

    public class NetWorthVisitor : IVisitor
    {
        public int Total { get; private set; }

        public void Visit(RealEstate realEstate) => Total += realEstate.EstimatedValue;
        public void Visit(BankAccount bankAccount) => Total += bankAccount.Amount;
        public void Visit(Loan loan) => Total -= loan.Owed;
    }

    public class MonthlyIncomeVisitor : IVisitor
    {
        public decimal Amount { get; private set; }

        public void Visit(RealEstate realEstate) => Amount += realEstate.MonthlyRent;
        public void Visit(BankAccount bankAccount) => Amount += Math.Round(bankAccount.Amount * bankAccount.InterestRate / 12, 2);
        public void Visit(Loan loan) => Amount -= loan.MonthlyPayment;
    }
}
