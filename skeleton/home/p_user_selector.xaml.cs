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
    public partial class p_user_selector : Border, page
    {
        api api;
        public p_user_selector()
        {
            InitializeComponent();
        }
        public UIElement z_ui => this;
        public string titel => "لیست کاربران ثبت شده";
        public void focus()
        {
            lst_users.SelectedIndex = 0;
            lst_users.UpdateLayout();
            var listBoxItem = (ListBoxItem)lst_users
                .ItemContainerGenerator
                .ContainerFromItem(lst_users.SelectedItem);
            listBoxItem.Focus();
        }
        public void start(api api)
        {
            this.api = api;
            lst_users.PreviewKeyDown += Lst_users_PreviewKeyDown;
        }
        async void Lst_users_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var dv = await api.message(z_message.e_type.info, "test", "op1", "op2");
        }
    }
}
