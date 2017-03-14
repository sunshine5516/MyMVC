using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageService.Entity
{
    /// <summary>
    /// 单个按钮
    /// </summary>
    public class SingleButton : BaseButton
    {
        /// <summary>
        /// 按钮类型
        /// </summary>
       public string type { get; set; }
        public SingleButton(string type)
        {
            this.type = type;
        }
    }
}
