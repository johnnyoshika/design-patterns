using DesignPatterns.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.ChainOfResponsibility
{
    public class ExpenseHandler_Should
    {
        [Fact]
        public void Approve_500_Expense()
        {
            var result = Manager.Approve(new ExpenseReport(500));
            Assert.Equal(ApprovalResponse.Approved, result);
        }

        [Fact]
        public void Approve_6000_Expense()
        {
            var result = Manager.Approve(new ExpenseReport(6000));
            Assert.Equal(ApprovalResponse.Approved, result);
        }

        [Fact]
        public void Approve_18000_Expense()
        {
            var result = Manager.Approve(new ExpenseReport(18000));
            Assert.Equal(ApprovalResponse.Approved, result);
        }

        [Fact]
        public void Deny_21000_Expense()
        {
            var result = Manager.Approve(new ExpenseReport(21000));
            Assert.Equal(ApprovalResponse.Denied, result);
        }

        IExpenseHandler Manager => new ExpenseHander(new Employee("William", decimal.Zero),
                new ExpenseHander(new Employee("Mary", 1000m),
                    new ExpenseHander(new Employee("Victor", 5000m),
                        new ExpenseHander(new Employee("Paula", 20000m)))));
    }
}
