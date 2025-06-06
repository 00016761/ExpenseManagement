using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;

namespace ExpenseManagement.Service.DTOs.ExpenseDTOs;

public class ExpenseForUpdateDto
{
    public string Name { get; set; }
    public long ExpenseCategoryId { get; set; }
    public decimal Amount { get; set; }
}
