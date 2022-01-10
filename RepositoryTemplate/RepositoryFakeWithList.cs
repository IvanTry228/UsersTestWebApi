using System;
using System.Linq;
using System.Collections.Generic;

namespace RepositoryTemplate
{
    public class RepositoryFakeWithList<T> : RepositoryAbstract<T> where T : class
    {
        IList<T> dataListEmmulate = new List<T>();

        public override IEnumerable<T> GetAll()
        {
            return dataListEmmulate;
        }
        public override void AddItem(T _entity)
        {
            dataListEmmulate.Add(_entity);
        }
        public override IQueryable<T> GetQueryableItems()
        {
            return dataListEmmulate.AsQueryable(); //return (IQueryable<T>)dataListEmmulate;
        }
    }
}
