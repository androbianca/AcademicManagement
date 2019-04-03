using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstractions
{
    public interface IRepository
    {
        ICollection<T> GetAll<T>()
            where T : class;
      
        T GetByFilter<T>(Expression<Func<T, bool>> filter)
            where T : class;

        ICollection<T> GetAllByFilter<T>(Expression<Func<T, bool>> filter)
            where T : class;

        void Insert<T>(T entity)
            where T : class;

        void Save();

        void Delete<T>(T entity)
            where T : class;
    }
}

