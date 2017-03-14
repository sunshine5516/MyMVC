using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class UploadManage : RepositoryBase<COM_UPLOAD>, IUploadManage, IRepository<COM_UPLOAD>
    {
    }
}
