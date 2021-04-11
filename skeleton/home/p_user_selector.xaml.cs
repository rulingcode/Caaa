using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        api api2;
        ListBox lst_users;
        ObservableCollection<m.user> list = new();
        m.user add_user = new() { id = "add_user", text = "افزودن یک کاربر جدید" };
        public p_user_selector()
        {
            InitializeComponent();
            lst_users = (ListBox)lst.child;
            list.Add(add_user);
            lst_users.ItemsSource = list;
            lst_users.DisplayMemberPath = nameof(m.user.text);
        }
        public FrameworkElement z_ui => this;
        public string title => "انتخاب کاربر";
        public e_size size => e_size.s2_phone;
        public void focus()
        {
            if (lst_users.SelectedItem == null)
                lst_users.SelectedItem = add_user;
            lst_users.UpdateLayout();
            var listBoxItem = (ListBoxItem)lst_users
                .ItemContainerGenerator
                .ContainerFromItem(lst_users.SelectedItem);
            listBoxItem?.Focus();
        }
        public async void start(api api2)
        {
            this.api2 = api2;
            lst_users.PreviewKeyDown += Lst_users_PreviewKeyDown;
            var dv = await a.api3.c_db.general<m.user>().all(i => true);
            foreach (var i in dv)
                list.Add(i);
        }
        async void Lst_users_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (lst_users.SelectedItem == add_user)
                {
                    var user = await api2.side(new p_add_user());
                    var dv = list.FirstOrDefault(i => i.id == user.id);
                    if (dv != null)
                        list.Remove(dv);
                    list.Add(user);
                    lst_users.SelectedItem = user;
                    focus();
                }
                else
                {
                    const string v = "حذف کابر";
                    var dv = await api2.message(z_message.e_type.info, "آیا مخواهید کاربر مورد نظر را از لیست حذف کنید؟",
                        "بازگشت", v);
                    if (dv == v)
                    {
                        m.user selectedItem = (m.user)lst_users.SelectedItem;
                        await a.api3.c_db.general<m.user>().delete(selectedItem.id);
                        list.Remove(selectedItem);
                        focus();
                    }
                }
            }
        }
    }
}
