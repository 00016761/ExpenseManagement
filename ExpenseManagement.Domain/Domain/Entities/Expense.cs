using ExpenseManagement.Domain.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Domain.Domain.Entities;

public class Expense : Auditable
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public required long ExpenseCategoryId { get; set; }
    public ExpenseCategory ExpenseCategory { get; set; }
}
