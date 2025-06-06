using AutoMapper;
using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;
using ExpenseManagement.Service.Exceptions;
using ExpenseManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly IRepository<ExpenseCategory> repository;
    private readonly IMapper mapper;

    public ExpenseCategoryService(IRepository<ExpenseCategory> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ExpenseCategoryForResultDto> CreateAsync(ExpenseCategoryForCreationDto dto)
    {
        var category = await this.repository.GetAll()
            .Where(c => c.CategoryName.ToLower() == dto.CategoryName.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (category is not null) 
            throw new CustomException(400, "category already exist");

        var mappedCategory = this.mapper.Map<ExpenseCategory>(dto);

        mappedCategory.CreatedAt = DateTime.UtcNow;

        var insertCategory = await this.repository.AddAsync(mappedCategory);
        await this.repository.SaveChangeAsync();
        return this.mapper.Map<ExpenseCategoryForResultDto>(mappedCategory);
    }

    public async Task<ExpenseCategoryForResultDto> GetByIdAsync(long id)
    {
        var category = await this.repository.GetAll()
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (category == null) throw new CustomException (404, "category not found");

        return new ExpenseCategoryForResultDto 
        {
            Id = category.Id, 
            CategoryName = category.CategoryName, 
            CreatedAt = category.CreatedAt, 
            UpdatedAt = category.UpdatedAt 
        };
    }

    public async Task<ExpenseCategoryForResultDto> UpdateAsync(long id, ExpenseCategoryForUpdateDto dto)
    {
        var category = await this.repository.GetByIdAsync(id);

        if (category == null) throw new CustomException(404, "category not found");

        var mappedCategory = this.mapper.Map(dto, category);

        await this.repository.SaveChangeAsync();

        return this.mapper.Map<ExpenseCategoryForResultDto>(mappedCategory);
        
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var category = await repository.GetByIdAsync(id);
        if (category == null) throw new CustomException(404, "category not found");
        
        await this.repository.DeleteAsync(id);

        return await this.repository.SaveChangeAsync();
    }

    public async Task<IEnumerable<ExpenseCategoryForResultDto>> RetrieveAllAsync(int pageIndex, int pageSize)
    {
        var categories = await this.repository.GetAll()
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<ExpenseCategoryForResultDto>>(categories);
    }
}