using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;
using ExpenseManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpenseManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseCategoriesController : ControllerBase
{
    private readonly IExpenseCategoryService expenseCategoryService;

    public ExpenseCategoriesController(IExpenseCategoryService expenseCategoryService)
    {
        this.expenseCategoryService = expenseCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]int pageIndex, [FromQuery]int pageSize)
    {
        var result = await this.expenseCategoryService.RetrieveAllAsync(pageIndex,pageSize);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ExpenseCategoryForCreationDto dto)
    {
        if (dto == null) return BadRequest("Invalid data");

        var result = await expenseCategoryService.CreateAsync(dto);
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await this.expenseCategoryService.GetByIdAsync(id);
        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] ExpenseCategoryForUpdateDto dto)
    {
        var result = await this.expenseCategoryService.UpdateAsync(id, dto);
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await this.expenseCategoryService.DeleteAsync(id);
        return Ok(result);
    }
}
