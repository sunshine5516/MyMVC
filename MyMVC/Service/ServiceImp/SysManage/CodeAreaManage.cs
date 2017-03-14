using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class CodeAreaManage : RepositoryBase<SYS_CODE_AREA>, ICodeAreaManage, IRepository<SYS_CODE_AREA>
    {
        public IQueryable<SYS_CODE_AREA> LoadCity(int provinceId)
        {
            return this.LoadAll((SYS_CODE_AREA p) => (int)p.LEVELS == 1 && p.PID == (int)provinceId);
        }

        public IQueryable<SYS_CODE_AREA> LoadCommunity(int countryId)
        {
            return this.LoadAll((SYS_CODE_AREA p) => (int)p.LEVELS == 4 && p.PID == countryId);
        }

        public IQueryable<SYS_CODE_AREA> LoadCountry(int cityId)
        {
            return this.LoadAll((SYS_CODE_AREA p) => (int)p.LEVELS == 2 && p.PID == cityId);
        }

        public IQueryable<SYS_CODE_AREA> LoadProvince()
        {
            return this.LoadAll((SYS_CODE_AREA p) => (int)p.LEVELS == 0);
        }
    }
}
