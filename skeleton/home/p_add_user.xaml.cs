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
    public partial class p_add_user : Border, page<string>
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
        }
        public Action<string> reply { get; set; }
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
        }

        async void Txt_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                layer_0.x_center.y_send_code y = new() { a_phoneid = txt_phone.Text };
                var dv = await api.run_null(y);
                if (dv.a_error != layer_0.x_center.y_send_code.error.non)
                {
                    await api.message(z_message.e_type.error, "شماره تلفن همراه وارد شده معتبر نیست.");
                }
            }
        }
    }
}