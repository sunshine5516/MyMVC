using System;
using System.Collections.Generic;
using WXPageModel;

namespace WXPageDomain.Abatract
{
    public interface IWXMemberRepository : IRepository<Member>
    {
        List<Member> FindWXMember();
    }
}
