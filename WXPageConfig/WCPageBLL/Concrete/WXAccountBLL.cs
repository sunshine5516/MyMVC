using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WXPageBLL.Abatract;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageModel;

namespace WXPageBLL.Concrete
{
    public class WXAccountBLL : IWXAccountBLL
    {
        private IWXAccountRepository _repository;
        public WXAccountBLL() : this(new EFWXAccountRepository()) 
        {
        }
        public WXAccountBLL(IWXAccountRepository repository)
        {
            _repository = repository;
        }
        public IQueryable<WXAccountInfo> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        public List<WXAccountInfo> FindAllInfo
        {
            get
            {
               return _repository.FindAllInfo;
            }
        }

        public void Delete(Expression<Func<WXAccountInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<WXAccountInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(WXAccountInfo entity)
        {
            //throw new NotImplementedException();
            var data = FindAllInfo.Where(p => p.Id == entity.Id).FirstOrDefault();
            if (data != null)
            {
                //data = wxAccount;
                _repository.Delete(data);
            }
        }
        /// <summary>
        /// 根据ID删除账号
        /// </summary>
        /// <param name="wxAccountId"></param>
        public void DeleteWXAccount(string wxAccountId)
        {
            _repository.DeleteWXAccount(wxAccountId);
            //throw new NotImplementedException();
        }

        public WXAccountInfo GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<WXAccountInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(WXAccountInfo entity)
        {
            var data = FindAllInfo.Where(p => p.Id == entity.Id).FirstOrDefault();
            if (data != null)
            {
                data = entity;
            }
            else
            {
                FindAllInfo.Add(entity);
            }
        }
    }
}
