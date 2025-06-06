using ExpenseManagement.Service.DTOs.ExpenseDTOs;
using ExpenseManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        this.expenseService = expenseService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var expenses = await this.expenseService.RetrieveAllAsync();
        return Ok(expenses);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseForResultDto>> GetByIdAsync(long id)
    {
        var expense = await this.expenseService.RetrieveByIdAsync(id);
        return Ok(expense);
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ExpenseForCreationDto dto)
    {
        var expense = await this.expenseService.CreateAsync(dto);
        return Ok(expense);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var expense = await this.expenseService.DeleteAsync(id);
        return Ok(expense);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> PutAsync(long id, ExpenseForUpdateDto dto)
    {
        var expense = await this.expenseService.UpdateAsync(id, dto);
        return Ok(expense);
    }
}
