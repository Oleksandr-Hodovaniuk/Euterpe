using System.Linq.Expressions;

namespace Catalog.Application.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query();
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
   
}
