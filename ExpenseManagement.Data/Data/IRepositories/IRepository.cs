using ExpenseManagement.Domain.Domain.Entities;

public interface IRepository<TEntity> 
{
    Task<bool> SaveChangeAsync();
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(long id);
    Task<TEntity> AddAsync(TEntity entity);
    void Update(TEntity entity); 
    Task DeleteAsync(long id);
}