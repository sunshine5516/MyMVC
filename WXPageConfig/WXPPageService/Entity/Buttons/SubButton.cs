using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageService.Entity
{
    /// <summary>
    /// 子菜单
    /// </summary>
    public class SubButton:BaseButton
    {
       public List<SingleButton> sub_button { get; set; }
        public SubButton()
        {
            sub_button = new List<SingleButton>();
        }
        public SubButton(string name) : this()
        {
            base.name = name;
        }
    }
}
