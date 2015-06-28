namespace DatabaseLayer
{
    using System;

    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(Guid id);
    }
}