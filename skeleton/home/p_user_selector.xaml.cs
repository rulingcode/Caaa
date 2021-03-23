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

namespace skeleton.home
{
    /// <summary>
    /// Interaction logic for p_user_selector.xaml
    /// </summary>
    public partial class p_user_selector : Border, page
    {
        public p_user_selector()
        {
            InitializeComponent();
        }
        public UIElement z_ui => this;
        public void focus()
        {
            throw new NotImplementedException();
        }
        public void start(api api)
        {
         
        }
    }
}
