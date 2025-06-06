using AutoMapper;
using ExpenseManagement.Domain.Domain.Entities;
using ExpenseManagement.Service.DTOs.ExpenseCategoryDTOs;
using ExpenseManagement.Service.DTOs.ExpenseDTOs;

namespace ExpenseManagement.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Expense, ExpenseForCreationDto>().ReverseMap();
        CreateMap<Expense, ExpenseForResultDto>().ReverseMap();
        CreateMap<Expense, ExpenseForUpdateDto>().ReverseMap();

        CreateMap<ExpenseCategory, ExpenseCategoryForCreationDto>().ReverseMap();
        CreateMap<ExpenseCategory, ExpenseCategoryForResultDto>().ReverseMap();
        CreateMap<ExpenseCategory, ExpenseCategoryForUpdateDto>().ReverseMap();
    }
}