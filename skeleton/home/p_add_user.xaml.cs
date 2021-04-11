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
    public partial class p_add_user : Border, page<m.user>
    {
        text_box txt_phone;
        PasswordBox txt_code;
        api api;
        e_state e;
        enum e_state
        {
            set_phone,
            set_code
        }
        public p_add_user()
        {
            InitializeComponent();
            txt_phone = (text_box)phone.child;
            txt_code = (PasswordBox)code.child;
            txt_phone.Text = "01234567890";
        }
        void reset()
        {
            switch (e)
            {
                case e_state.set_phone:
                    {
                        code.Visibility = Visibility.Collapsed;
                    }
                    break;
                case e_state.set_code:
                    {
                        code.Visibility = Visibility.Visible;
                    }
                    break;
            }
            focus();
        }
        public Action<m.user> reply { get; set; }
        public FrameworkElement z_ui => this;
        public e_size size => e_size.s2_phone;
        public string title => "افزودن یک کاربر جدید";
        public void focus()
        {
            switch (e)
            {
                case e_state.set_phone:
                    txt_phone.Focus();
                    break;
                case e_state.set_code:
                    txt_code.Focus();
                    break;
            }
        }
        public void start(api api2)
        {
            this.api = api2;
            reset();
            txt_phone.PreviewKeyDown += Txt_phone_PreviewKeyDown;
            txt_code.PreviewKeyDown += Txt_code_PreviewKeyDown;
            txt_phone.TextChanged += Txt_phone_TextChanged;
        }
        private void Txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.e != e_state.set_phone)
            {
                this.e = e_state.set_phone;
                reset();
            }
        }
        async void Txt_code_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txt_code.Password?.Length == 5)
                {
                    layer_0.x_center.y_phone_login y = new();
                    y.a_phoneid = txt_phone.Text;
                    y.a_password = txt_code.Password;
                    var dv = await api.run(y);
                    if (dv.a_error == layer_0.x_center.y_phone_login.error.non)
                    {
                        var db = a.api3.c_db.general<m.user>();
                        m.user val = new m.user()
                        {
                            id = dv.a_userid,
                            text = txt_phone.Text
                        };
                        await db.upsert(val);
                        reply(val);
                    }
                    else
                    {
                        await invalid_code_message();
                    }
                }
                else
                    await invalid_code_message();
            }
        }
        private async Task invalid_code_message()
        {
            await api.message(z_message.e_type.error, "کد فعال سازی صحیح نیست.");
        }
        async void Txt_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (is_valid_phone())
                {
                    await invalid_phone_message();
                    return;
                }
                layer_0.x_center.y_send_code y = new() { a_phoneid = txt_phone.Text };
                var dv = await api.run(y);
                if (dv.a_error == layer_0.x_center.y_send_code.error.non)
                {
                    this.e = e_state.set_code;
                    reset();
                }
                else
                {
                    await invalid_phone_message();
                }
            }
        }
        private bool is_valid_phone()
        {
            return txt_phone.Text.Length != 11;
        }
        private async Task invalid_phone_message()
        {
            await api.message(z_message.e_type.error, "شماره تلفن همراه وارد شده معتبر نیست.");
        }
    }
}