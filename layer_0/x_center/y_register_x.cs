using layer_0.cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layer_0.x_center
{
    public class y_register_x : y<y_register_x.o>
    {
        public override string z_xid => all_command.x_center;
        public override string z_yid => nameof(y_register_x);
        public override e_permission z_permission => e_permission.non;
        public byte[] a_key_data { get; set; }
        public byte[] a_register_data { get; set; }
        public class o : o_base
        {
            public string a_deviceid { get; set; }
        }
    }
}
