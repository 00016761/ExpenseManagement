
namespace ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;

public class ExpenseCategoryForResultDto
{
    public long Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}
