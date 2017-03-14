using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WXPageBLL.Abatract
{
    public interface IBLL<T> where T : class
    {
        /// <summary>
        /// 获取查询实体集
        /// </summary>
        IQueryable<T> FindAll { get; }
        List<T> FindAllInfo { get; }
        void Save(T entity);
        void Save(IEnumerable<T> entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);
        //void Add(T entity);
        /// <summary>
        /// 删除符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetByKey(object key);
    }
}
