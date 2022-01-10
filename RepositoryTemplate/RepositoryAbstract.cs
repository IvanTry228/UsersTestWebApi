using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RepositoryTemplate
{
    public abstract class RepositoryAbstract<T> : IRepositoryEntity<T> where T : class
    {
        private DbSet<T> currentDbSet;
        private DbContext currentDbContext;

        public virtual void AddItem(T _entity)
        {
            currentDbSet.Add(_entity);
        }

        public virtual void UpdateItem(T _entity)
        {
            currentDbSet.Update(_entity);
        }

        public virtual T GetItemById(int _id)
        {
            T bufferFinded = currentDbSet.Find(_id);
            return bufferFinded;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return currentDbSet;
        }

        public virtual IQueryable<T> GetQueryableItems()
        {
            return currentDbSet;
        }

        public virtual void RemoveItem(T _entity)
        {
            currentDbSet.Remove(_entity);
        }

        public void SetQueryableItems(IQueryable<T> _setQueryableItems)
        {
            throw new NotImplementedException();
        }

        public void SetInjectDbSetEntity(DbSet<T> _injectedDb)
        {
            currentDbSet = _injectedDb;
        }

        public void SaveChangesApply()
        {
            if (currentDbContext != null)
                currentDbContext.SaveChanges();
            else
                Console.WriteLine("RepositoryAbstract SaveChangesApply currentDbContext == null");
        }

        public void SetInjectAppDbContext(DbContext _dbContext)
        {
            currentDbContext = _dbContext;
        }
    }
}
