using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainOfResponsibility
{
    public interface IExpenseReport
    {
        public decimal Amount { get; }
    }

    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport(decimal amount) => Amount = amount;

        public decimal Amount { get; }
    }
}
