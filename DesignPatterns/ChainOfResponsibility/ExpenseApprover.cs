namespace DesignPatterns.ChainOfResponsibility
{
    public interface IExpenseApprover
    {
        ApprovalResponse ApproveExpense(IExpenseReport report);
    }

    public class Employee : IExpenseApprover
    {
        public Employee(string name, decimal approvalLimit)
        {
            Name = name;
            ApprovalLimit = approvalLimit;
        }

        public string Name { get; }
        public decimal ApprovalLimit { get; }

        public ApprovalResponse ApproveExpense(IExpenseReport report) =>
            report.Amount > ApprovalLimit
                ? ApprovalResponse.BeyondLimit
                : ApprovalResponse.Approved;
    }
}
