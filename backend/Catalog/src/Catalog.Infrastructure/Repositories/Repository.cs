using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories;

internal class Repository<T>(ApplicationDbContext _context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Remove(T entity)
    {
        _context.Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
