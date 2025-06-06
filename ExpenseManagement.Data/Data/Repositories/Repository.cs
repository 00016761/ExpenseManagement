using ExpenseManagement.Data.AppsDbContext;
using ExpenseManagement.Domain.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = appDbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var expense = await this.dbSet.AddAsync(entity);
        return expense.Entity;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        this.dbSet.Remove(entity);
    }

    public IQueryable<TEntity> GetAll()
       => dbSet;

    public async Task<TEntity> GetByIdAsync(long id)
    => await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> SaveChangeAsync()
        => await this.appDbContext.SaveChangesAsync() > 0;

    public void Update(TEntity entity)
        => this.dbSet.Update(entity);
}
