using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WXPageDomain.Abatract;
using WXPageModel;

namespace WXPageDomain.Concrete
{
    public class EFWXMemberRepository : BaseRepository<Member>, IWXMemberRepository
    {
        public static List<Member> WXMemberList = new List<Member>()
        {
            new Member { Id="1",Account="testAccount001",Password="wxfd537a1b809515aa",Name="2ad4fa081250612384f04bbbd7bb6df0",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="2",Account="12@qq.com",Password="A39F858FB2694A768CA5F01D45A5A17860D559FD",Name="22222222",State="冻结",NickName="rqwe235trgfgasd",AuthCode=null,InsertTime=DateTime.Now},
            new Member { Id="3",Account="testAccount003",Password="34567456",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="4",Account="testAccount004",Password="222222222",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="5",Account="testAccount005",Password="890678966",Name="22222222",State="冻结",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="6",Account="testAccount006",Password="000000000",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="7",Account="testAccount007",Password="666666666",Name="22222222",State="过期",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="8",Account="testAccount008",Password="567354362",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="9",Account="testAccount009",Password="456345642",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now},
            new Member { Id="10",Account="testAccount010",Password="067845674",Name="22222222",State="正常",NickName="rqwe235trgfgasd",AuthCode="wx1",InsertTime=DateTime.Now}
        };
        public List<Member> FindWXMember()
        {
            throw new NotImplementedException();
        }

        public void Save(Member entity)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<Member> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Member> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Member GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public List<Member> FindAllInfo
        {
            get
            {
                return WXMemberList;

            }
        }

        public IQueryable<Member> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
