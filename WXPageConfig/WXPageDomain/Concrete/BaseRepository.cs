using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WXPageDomain.Abatract;

namespace WXPageDomain.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<T> FindAllInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
