using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace skeleton
{
    public interface page
    {
        FrameworkElement z_ui { get; }
        void focus();
        void start(api api);
        e_size size { get; }
        string title { get; }
        void close();
    }
    public interface page<T> : page
    {
        Action<T> reply { get; set; }
    }
}
