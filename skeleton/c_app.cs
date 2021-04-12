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
        internal page_factory developer_factory = default;
        List<api> list = new();
        SemaphoreSlim locker = new SemaphoreSlim(1, 1);
        async Task<api> get(string appid)
        {
            return default;
        }
        public void programing(page_factory factory)
        {
            developer_factory = factory;
        }
        public void set_user(string userid)
        {

        }
    }
}