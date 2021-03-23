using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace skeleton
{
    public abstract class z_app
    {
        List<item> list = new List<item>();
        class item
        {
            public string name;
            public Type type;
        }
        public string appid { get; internal set; }
        public static void programing(Window window, z_app app) => connection.programing(window, app);
        public abstract string app_name { get; }
        public string[] pages_name { get; private set; }
        public void add<T>(string name) where T : api
        {
            if (list.Any(i => i.name == name))
                throw new Exception("kkjbjgjbjfjvhdhchd");
            list.Add(new item() { name = name, type = typeof(T) });
            pages_name = list.Select(i => i.name).ToArray();
        }
        internal Type get_type(string page_name) => list.FirstOrDefault(i => i.name == page_name)?.type;
    }
}