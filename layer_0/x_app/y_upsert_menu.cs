using layer_0.cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layer_0.x_app
{
    public class y_upsert_menu : z_y<y_upsert_menu.o>
    {
        public override string z_yid => nameof(y_upsert_menu);
        public string a_appid { get; set; }
        public e_action a_action { get; set; }
        public class o : o_base { }
        public enum e_action
        {
            add,
            remove
        }
    }
}
