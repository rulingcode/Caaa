using layer_0.cell;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace layer_3.c
{
    class db<T> : c_db<T> where T : m_id
    {
        async Task<o> run<o>(Func<o> func)
        {
            TaskCompletionSource<o> rt = new TaskCompletionSource<o>();
            ThreadPool.QueueUserWorkItem(met);
            void met(object o)
            {
                var dv = func();
                rt.SetResult(dv);
            }
            return await rt.Task;
        }
        async Task run(Action func)
        {
            TaskCompletionSource rt = new TaskCompletionSource();
            ThreadPool.QueueUserWorkItem(met);
            void met(object o)
            {
                func();
                rt.SetResult();
            }
            await rt.Task;
        }
        ILiteCollection<T> coll { get; }
        internal db(ILiteCollection<T> coll) => this.coll = coll;
        public async Task<bool> any(Expression<Func<T, bool>> filter) => await run(() => coll.Find(filter).Any());
        public async Task<T> get(string id) => await run(() => coll.FindOne(i => i.id == id));
        public async Task<T> get(Expression<Func<T, bool>> filter) => await run(() => coll.FindOne(filter));
        public async Task upsert(T val) => await run(() => coll.Upsert(val));
        public async Task delete(string id) => await run(() => coll.Delete(id));
        public async Task delete_many(Expression<Func<T, bool>> p) => await run(() => coll.DeleteMany(p));
        public async Task<IEnumerable<T>> all(Expression<Func<T, bool>> filter) => await run(() => coll.Find(filter).ToArray());
    }
}
