using layer_0.cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layer_0.x_app
{
    public class y_upsert_app_data : z_y<y_upsert_app_data.o>
    {
        public override e_permission z_permission => e_permission.u;
        public override string z_yid => nameof(y_upsert_app_data);
        public string a_appid { get; set; }
        public byte[] a_data { get; set; }
        public class o : o_base { }
    }
}
