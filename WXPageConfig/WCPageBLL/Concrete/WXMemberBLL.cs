using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WCPageBLL.Abatract;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageModel;

namespace WCPageBLL.Concrete
{
    public class WXMemberBLL : IWXMemberBLL
    {
        private IWXMemberRepository _repository;
        public WXMemberBLL() : this(new EFWXMemberRepository()) 
        {
        }
        public WXMemberBLL(IWXMemberRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Member> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<Member> FindAllInfo
        {
            get
            {
                return _repository.FindAllInfo;
            }
        }

        public void Delete(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Member> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        public Member GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<Member> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
