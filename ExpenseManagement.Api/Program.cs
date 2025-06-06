
using ExpenseManagement.Api.Middlewares;
using ExpenseManagement.Data.AppsDbContext;
using ExpenseManagement.Data.Data.Repositories;
using ExpenseManagement.Service.Interfaces;
using ExpenseManagement.Service.Mappers;
using ExpenseManagement.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ExpenseManagement.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(option
            => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("ExpenseManagement.Data")));

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IExpenseService, ExpenseService>();
        builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));


        //Middlewares
        var app = builder.Build();

        app.UseCors("AllowAllOrigins");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
