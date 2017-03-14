using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXPageDomain.Models;

namespace WXPageDomain.Abatract
{
    public interface IWXReplayContentsRepository : IRepository<ReplayContents>
    {
        List<ReplayContents> ReplayContent { get; }
        void SaveReplayContents(ReplayContents wxReplayContent);
        void DeleteReplayContents(string wxReplayContentId);
        ReplayContents GetReplayContent(string wxAccontID);
    }
}
