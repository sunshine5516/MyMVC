using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// 地区管理
    /// </summary>
    public interface ICodeAreaManage : IRepository<SYS_CODE_AREA>
    {
        IQueryable<SYS_CODE_AREA> LoadProvince();
        IQueryable<SYS_CODE_AREA> LoadCity(int provinceId);
        IQueryable<SYS_CODE_AREA> LoadCountry(int cityId);
        IQueryable<SYS_CODE_AREA> LoadCommunity(int countryId);
    }
}
