using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;
using ExpenseManagement.Service.DTOs.ExpenseDTOs;

namespace ExpenseManagement.Service.Interfaces;

public interface IExpenseCategoryService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<ExpenseCategoryForResultDto>> RetrieveAllAsync(int pageIndex, int pageSize);
    Task<ExpenseCategoryForResultDto> GetByIdAsync(long id);
    Task<ExpenseCategoryForResultDto> CreateAsync(ExpenseCategoryForCreationDto dto);
    Task<ExpenseCategoryForResultDto> UpdateAsync(long id, ExpenseCategoryForUpdateDto dto);
}
