using EmployeeData.Contracts;
using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeData.Repos
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    public MasterContext MasterContext { get; set; }

    protected DbSet<T> _Set { get; set; }

    public RepositoryBase(MasterContext context)
    {
      MasterContext = context;
      _Set = context.Set<T>();
    }

    public async void Create(T entity)
    {
      _Set.Add(entity);
      await MasterContext.SaveChangesAsync();
    }

    public async void Delete(T entity)
    {
      if (_Set.Find(entity) != null)
      {
        _Set.Remove(entity);
        await MasterContext.SaveChangesAsync();
      }
    }

    public async Task<List<T>> FindAll()
    {
      await _Set.LoadAsync();
      return _Set.ToList();
    }

    public async Task<List<T>> FindByCondition(Func<T, bool> expression)
    {
      await _Set.LoadAsync();
      var result = _Set.Where(expression).ToList();
      return result;
    }

    public async void Update(T entity)
    {
      _Set.Attach(entity);
      MasterContext.Entry(entity).State = EntityState.Modified;

      try
      {
        await MasterContext.SaveChangesAsync();
      }
      catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
      {
        throw ex;
      }
    }

    private Expression<Func<T, object>>[]? _Includes;

    protected Expression<Func<T, object>>[] Includes
    {
      get { return _Includes; }
    }

    public void SetIncludes(params Expression<Func<T, object>>[] includes)
    {
      _Includes = includes;
    }

    protected IQueryable<T> ApplyIncludes(IQueryable<T> query)
    {
      if (_Includes != null)
      {
        foreach (var include in _Includes)
        {
          query = query.Include(include);
        }
      }

      _Includes = null;

      return query;
    }

    protected virtual IQueryable<T> Query()
    {
      var query = _Set.AsQueryable();

      query = ApplyIncludes(query);

      return query;
    }

    protected virtual T FindWhere(Expression<Func<T, bool>> condition)
    {
      try
      {
        T entity = Query().Single(condition);
        return entity;
      }
      catch (InvalidOperationException)
      {
        return null;
      }
    }
  }
}
