namespace EmployeeData.Contracts
{
    public interface ITransactionContext : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Flush();
    }
}