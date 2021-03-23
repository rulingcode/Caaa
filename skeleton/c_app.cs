using layer_0.cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skeleton
{
    class c_app
    {
        internal z_app developer_app = default;
        List<api> list = new List<api>();
        SemaphoreSlim locker = new SemaphoreSlim(1, 1);
        async Task<z_app> get(string appid)
        {
            if (developer_app != null && developer_app.appid == all_command.developer_app)
                return await Task.FromResult(developer_app);
            return default;
        }
        public async Task<string[]> get_pages(string appid)
        {
            var dv = await get(appid);
            return dv.pages_name;
        }
        public async Task show(string userid, string appid, string pageid)
        {
            await locker.WaitAsync();
            var page = list.FirstOrDefault(i => i.userid == userid && i.z_appid == appid && i.z_name == pageid);
            locker.Release();
            if (page == null)
            {
                var app = await get(appid);
                if (app == null)
                    throw new Exception("kbkhgjjkrjvjgjbfjbfmdnb");
                var type = app.get_type(pageid);
                if (type == null)
                    throw new Exception("kgkbhjbhfjbjgjbjfjfjbjg");
                page = Activator.CreateInstance(type) as api;
                page.userid = userid;
                page.z_name = pageid;
                page.z_appid = appid;
                await locker.WaitAsync();
                list.Add(page);
                locker.Release();
                a.main_panel.show(page);
            }

        }
    }
}