using layer_0.cell;
using layer_2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace skeleton
{
    public class api
    {
        z_dialog dialog = default;
        SemaphoreSlim g_locker = new SemaphoreSlim(1, 1);
        internal Grid z_body = new Grid();
        Border dialog_box = new Border() { Visibility = Visibility.Collapsed, Background = new SolidColorBrush(Color.FromArgb(70, 0, 0, 0)) };
        private readonly page page;
        public api(page page)
        {
            this.page = page;
        }
        public c_run run { get; internal set; }
        public string z_appid { get; internal set; }
        public string userid { get; internal set; }
        public string z_name { get; internal set; }
        internal void z_focus()
        {
            if (dialog == null)
                page.focus();
            else
                dialog.focus_();
        }
        public api()
        {
            z_body.Children.Add(page.z_ui);
            z_body.Children.Add(dialog_box);
        }
        public async Task<T> run_dialog<T>(z_dialog z)
        {
            await g_locker.WaitAsync();
            this.dialog = z;
            dialog_box.Child = z.ui;
            dialog_box.Visibility = Visibility.Visible;
            page.z_ui.IsEnabled = false;
            var dv = await z.get();
            dialog = null;
            page.z_ui.IsEnabled = true;
            page.focus();
            dialog_box.Visibility = Visibility.Collapsed;
            dialog_box.Child = default;
            g_locker.Release();
            return (T)dv;
        }
        public async Task<string> message(z_message.e_type e, string text, params string[] options)
        {
            z_message y = new z_message()
            {
                e = e,
                option = options,
                text = text,
            };
            var o = await y.run(this);
            return o.result;
        }
    }
}
