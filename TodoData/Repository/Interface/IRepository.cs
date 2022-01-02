﻿namespace TodoData.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T? Get(object? id);
        void Add(T? entity);
        void Remove(object? id);
    }
}
