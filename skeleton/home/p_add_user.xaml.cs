using skeleton.more_controls;
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
    /// Interaction logic for p_add_user.xaml
    /// </summary>
    public partial class p_add_user : Border
    {
        text_box txt_phone;
        PasswordBox txt_password;
        public p_add_user()
        {
            InitializeComponent();
            txt_phone = (text_box)phone.child;
        }
    }
}
