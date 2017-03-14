using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class ChatMessageManage : RepositoryBase<SYS_CHATMESSAGE>, IChatMessageManage, IRepository<SYS_CHATMESSAGE>
    {
    }
}
