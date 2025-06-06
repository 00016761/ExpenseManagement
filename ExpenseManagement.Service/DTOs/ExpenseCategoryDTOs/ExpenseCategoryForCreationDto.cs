using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseDTOs;

namespace ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;

public class ExpenseCategoryForCreationDto
{
    public string CategoryName { get; set; }
}