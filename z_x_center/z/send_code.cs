using layer_0.cell;
using layer_0.x_center;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using z_x_center.m;

namespace z_x_center.z
{
    class send_code : y_send_code
    {

        protected async override void implement()
        {
            if (!valid_phone(a_phoneid))
            {
                reply(new output() { a_error = error.invalid_phone });
                return;
            }
            var db = z_db.general_x<user>();
            var dv = await db.get(i => i.phoneid == a_phoneid);
            if (dv == null)
            {
                dv = new user()
                {
                    phoneid = a_phoneid,
                    first_time = DateTime.Now,
                    last_time = DateTime.Now,
                    password = new_pass(),
                    id = "u_" + ObjectId.GenerateNewId()
                };
                await db.upsert(dv);
            }
            else
                if (dv.password == null)
            {
                dv.last_time = DateTime.Now;
                dv.password = new_pass();
                await db.upsert(dv);
            }
            reply();
        }
        public bool valid_phone(string val) => val?.Length == 11;
        private static string new_pass()
        {
            return "12345";
        }
    }
}
