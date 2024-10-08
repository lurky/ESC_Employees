﻿namespace EmployeeData.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> FindAll();
        Task<List<T>> FindByCondition(Func<T, bool> expression);
    }
}
