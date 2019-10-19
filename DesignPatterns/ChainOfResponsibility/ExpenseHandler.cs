using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainOfResponsibility
{

    public interface IExpenseHandler
    {
        ApprovalResponse Approve(IExpenseReport report);
    }

    public class ExpenseHander : IExpenseHandler
    {
        public ExpenseHander(IExpenseApprover approver, IExpenseHandler? next = null) =>
            (Approver, Next) = (approver, next ?? EndOfChangeExpenseHandler.Instance);

        IExpenseApprover Approver { get; }
        IExpenseHandler Next { get; }

        public ApprovalResponse Approve(IExpenseReport report) =>
            Approver.ApproveExpense(report) == ApprovalResponse.BeyondLimit
                ? Next.Approve(report)
                : Approver.ApproveExpense(report);
    }

    public class EndOfChangeExpenseHandler : IExpenseHandler
    {
        EndOfChangeExpenseHandler() {}

        public static EndOfChangeExpenseHandler Instance = new EndOfChangeExpenseHandler();

        public ApprovalResponse Approve(IExpenseReport report) => ApprovalResponse.Denied;
    }
}
