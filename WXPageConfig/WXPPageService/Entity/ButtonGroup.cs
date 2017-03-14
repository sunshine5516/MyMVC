using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageService.Entity
{
    public class ButtonGroup
    {
        /// <summary>
        /// 按钮数，为1-3个
        /// </summary>
        public List<BaseButton> button { get; set; }
        public ButtonGroup()
        {
            button = new List<BaseButton>();
        }
    }
}
