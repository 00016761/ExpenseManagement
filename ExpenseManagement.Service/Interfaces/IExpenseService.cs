using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;
using ExpenseManagement.Service.DTOs.ExpenseDTOs;

namespace ExpenseManagement.Service.Interfaces;

public interface IExpenseService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<ExpenseForResultDto>> RetrieveAllAsync();
    Task<ExpenseForResultDto> RetrieveByIdAsync(long id);
    Task<ExpenseForResultDto> UpdateAsync(long id, ExpenseForUpdateDto dto);
    Task<ExpenseForResultDto> CreateAsync(ExpenseForCreationDto dto);
}
