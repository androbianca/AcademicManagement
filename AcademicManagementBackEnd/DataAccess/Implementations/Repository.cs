using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstractions;
using Entities;

namespace DataAccess.Implementations
{
    public class Repository : IRepository
    {
        public ICollection<T> GetAll<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public T GetByFilter<T>(Expression<Func<T, bool>> filter) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
