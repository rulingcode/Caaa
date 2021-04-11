using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace layer_0.cell
{
    public interface c_db<T> where T : m_id
    {
        Task upsert(T val);
        Task<T> get(string id);
        Task<T> get(Expression<Func<T, bool>> filter);
        Task<bool> any(Expression<Func<T, bool>> filter);
        Task delete(string id);
        Task delete_many(Expression<Func<T, bool>> p);
        Task<IEnumerable<T>> all(Expression<Func<T, bool>> filter);
    }
}
