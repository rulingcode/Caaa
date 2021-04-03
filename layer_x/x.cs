using layer_0.cell;
using layer_0.x_center;
using layer_3;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace layer_x
{
    public static class x
    {
        public static s_db_factory db => a.api3.s_db;
        public static c_run run_x { get; private set; }
        public static c_run run_null { get; private set; }
        public static void add_y<T>() where T : y, new() => a.api3.s_add_y<T>();
        public static void z_create<T>(Window window) where T : m_sync, new()
        {
            T dv = new T();
            a.xid = dv.z_xid;
            a.api3 = api3_factory.create<T>(a.xid);
            window.Title = a.xid;
            run_x = a.api3.c_run(a.xid);
            run_null = a.api3.c_run();
            a.key = new key();
            a.body = new body();
            window.Content = a.body;
            a.body.connection.start();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.WindowState = WindowState.Minimized;
        }
    }
}