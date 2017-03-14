using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class UserOnlineManag: RepositoryBase<SYS_USER_ONLINE>, IUserOnlineManage, IRepository<SYS_USER_ONLINE>
    {
    }
}
