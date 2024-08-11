using Microsoft.EntityFrameworkCore;
using Pschool.Infrastructure.Data;
using Pschool.Infrastructure.IRepositories;

namespace Pschool.Infrastructure.Repositories;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }
    public async Task<T?> GetByEmailAsync(string? email)
    {
        
        return await context.Set<T>().SingleOrDefaultAsync(e => EF.Property<string>(e, "Email") == email);
    }


    public async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
        
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}