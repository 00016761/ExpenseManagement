using AutoMapper;
using ExpenseManagement.Data.Data.Repositories;
using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseDTOs;
using ExpenseManagement.Service.Exceptions;
using ExpenseManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Service.Services;

public class ExpenseService : IExpenseService
{
    public readonly IRepository<Expense> repository;
    public readonly IRepository<ExpenseCategory> categoryRepository;
    public readonly IMapper mapper;

    public ExpenseService(IRepository<Expense> repository, IRepository<ExpenseCategory> categoryRepository, IMapper mapper)
    {
        this.repository = repository;
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    public async Task<ExpenseForResultDto> CreateAsync(ExpenseForCreationDto dto)
    {
        var category = await this.categoryRepository.GetByIdAsync(dto.ExpenseCategoryId);
        if (category == null)
            throw new CustomException(404, "ExpenseCategory not found");

        var mappedExpense = this.mapper.Map<Expense>(dto);

        mappedExpense.CreatedAt = DateTime.UtcNow;

        var insertExpense = await this.repository.AddAsync(mappedExpense);
        await this.repository.SaveChangeAsync();

        return this.mapper.Map<ExpenseForResultDto>(insertExpense);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var expense = await this.repository.GetByIdAsync(id);
        if (expense == null) throw new CustomException(404, "expense not found");

        await this.repository.DeleteAsync(id);

        return await this.repository.SaveChangeAsync();
    }

    public async Task<IEnumerable<ExpenseForResultDto>> RetrieveAllAsync()
    { 
        var expense = await this.repository.GetAll()
            .AsNoTracking()
            .Include(e => e.ExpenseCategory)
            .OrderBy(e => e.Id) 
            .ToListAsync();

        Console.WriteLine($"Expensies count: {expense.Count}");

        return this.mapper.Map<IEnumerable<ExpenseForResultDto>>(expense);
    }

    public async Task<ExpenseForResultDto> RetrieveByIdAsync(long id)
    {
        var expense = await this.repository.GetAll()
            .Include(e => e.ExpenseCategory)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (expense == null) throw new CustomException(404, "expense not found");

        return this.mapper.Map<ExpenseForResultDto>(expense);
    }

    public async Task<ExpenseForResultDto> UpdateAsync(long id, ExpenseForUpdateDto dto)
    {
        var expense = await this.repository.GetAll()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (expense == null) throw new CustomException(404, "expense not found");

        var mappedExpense = this.mapper.Map(dto, expense);
        mappedExpense.UpdatedAt = DateTime.UtcNow;

        await this.repository.SaveChangeAsync();

        return this.mapper.Map<ExpenseForResultDto>(mappedExpense);
    }
}
