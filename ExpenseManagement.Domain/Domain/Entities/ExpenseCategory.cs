using ExpenseManagement.Domain.Domain.Commons;

namespace ExpenseManagement.Domain.Domain.Entities;

public class ExpenseCategory : Auditable
{
    public string CategoryName { get; set; }
    public ICollection<Expense> Expenses { get; set; }
}
