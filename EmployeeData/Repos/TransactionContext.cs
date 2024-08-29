using EmployeeData.Contracts;
using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Repos
{
    public class TransactionContext : ITransactionContext
  {
    public TransactionContext(MasterContext context)
    {
      Context = context;
    }

    internal MasterContext Context { get; set; }

    public void Commit()
    {
      CommitAsync().Wait();
    }

    public void Flush()
    {
      var entries = Context.ChangeTracker.Entries().Where(e => e.State != EntityState.Detached).ToList();
      entries.ForEach(e => e.State = EntityState.Detached);
    }

    public Task CommitAsync()
    {
      return Context.SaveChangesAsync();
    }

    public void Dispose()
    {
      Context.Dispose();
    }
  }
}