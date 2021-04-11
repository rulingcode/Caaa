using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace skeleton
{
    public abstract class page_factory
    {
        public abstract string id { get; }
        public abstract page create();
        public static void run(Window window, page_factory factory)
        {
            connection.programing(window);
        }
    }
}
