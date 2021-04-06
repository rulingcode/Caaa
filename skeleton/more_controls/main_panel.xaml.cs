using skeleton.home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skeleton.more_controls
{
    /// <summary>
    /// Interaction logic for main_panel.xaml
    /// </summary>
    public partial class main_panel : Grid
    {
        public main_panel()
        {
            InitializeComponent();
            v_stack.Children.Clear();
            for (int i = 0; i < 15; i++)
                v_stack.Children.Add(new icon() { text = "نرم افزار" + i });
            first_show();
        }
        async void first_show()
        {
            await Task.Delay(1000);
            a.user_selector = new api(new p_user_selector());
            show(a.user_selector);
        }

        public void set(string[] apps, int app, string pages, int page)
        {

        }
        internal void show(api val)
        {
            a.api = val;
            stage.Child = val.stack;
            val.z_focus();
        }
    }
}
