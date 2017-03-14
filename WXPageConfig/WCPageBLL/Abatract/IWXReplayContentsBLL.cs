using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageDomain.Models;

namespace WXPageBLL.Abatract
{
    /// <summary>
    /// 回复业务处理
    /// </summary>
    public interface IWXReplayContentsBLL:IBLL<ReplayContents>
    {
        List<ReplayContents> ReplayContent { get; }
        void SaveReplayContents(ReplayContents wxReplayContent);
        void DeleteReplayContents(string wxReplayContentId);
        ReplayContents GetReplayContent(string wxAccontID);
    }
}
