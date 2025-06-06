using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;

namespace ExpenseManagement.Service.DTOs.ExpenseDTOs;

public class ExpenseForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public ExpenseCategoryForResultDto ExpenseCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}