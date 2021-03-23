using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skeleton
{
    class user_menu_factory
    {
        List<c_menu> list = new List<c_menu>();
        SemaphoreSlim locker = new SemaphoreSlim(1, 1);
        c_menu body;
        public async void set(string userid)
        {
            await locker.WaitAsync();
            var dv = list.FirstOrDefault(i => i.userid == userid);
            if (dv == null)
            {
                dv = new c_menu(userid);
                dv.reset += Dv_reset;
                list.Add(dv);
            }
            locker.Release();
            body = dv;
        }
        private void Dv_reset(c_menu obj)
        {
           
        }
    }
}
