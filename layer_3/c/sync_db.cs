using layer_0.cell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace layer_3.c
{
    class sync_db<T> : IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged where T : m_id
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        bool is_set = false;
        Expression<Func<T, bool>> filter;
        public sync_db(string userid)
        {
            this.userid = userid;
        }
        public string userid { get; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void set(Expression<Func<T, bool>> filter)
        {
            if (!is_set)
            {
                is_set = true;
                
            }

        }
    }
}