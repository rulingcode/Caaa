using layer_0.cell;
using skeleton.more_controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace skeleton
{
    public class api
    {
        internal StackPanel stack = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(1) };
        api_ui api_ui = new api_ui() { HorizontalAlignment = HorizontalAlignment.Left };
        page main_page;
        page dialog_page;
        int n_lock_screen = 0;
        SolidColorBrush color = new SolidColorBrush(Color.FromArgb(70, 0, 0, 0));
        loading loading = new loading();
        c_run c_run { get; }
        internal api(page page, c_run c_run)
        {
            this.c_run = c_run;
            api_ui.heder.text = page.title;
            set(page);
            stack.Children.Add(api_ui);
            main_page = page;
            api_ui.stage.Children.Add(page.z_ui);
            page.start(this);
        }
        public void close()
        {
            if (dialog_page == null)
                main_page.close();
            else
                dialog_page.close();
        }
        public async Task<T> run<T>(y<T> val, bool lock_screen = true) where T : o_base, new()
        {
            if (lock_screen)
                this.lock_screen(true);
            var dv = await val.run(c_run);
            if (lock_screen)
                this.lock_screen(false);
            return dv;
        }
        public void lock_screen(bool add = false)
        {
            if (add)
            {
                n_lock_screen++;
                if (n_lock_screen == 1)
                {
                    reset();
                    api_ui.stage.Children.Add(loading);
                }
            }
            else
            {
                n_lock_screen--;
                if (n_lock_screen == 0)
                {
                    reset();
                    api_ui.stage.Children.Remove(loading);
                }
            }
        }
        private void reset()
        {
            if (n_lock_screen == 0)
            {
                main_page.z_ui.IsEnabled = true;
                if (dialog_page != null)
                    dialog_page.z_ui.IsEnabled = true;
                z_focus();
            }
            else
            {
                main_page.z_ui.IsEnabled = false;
                if (dialog_page != null)
                    dialog_page.z_ui.IsEnabled = false;
            }
        }
        void set(page page)
        {
            switch (page.size)
            {
                case e_size.s1_menu:
                    page.z_ui.MinWidth = 180;
                    break;
                case e_size.s2_phone:
                    page.z_ui.Width = 300;
                    break;
                case e_size.s3_tablet:
                    break;
                case e_size.s4_desktop:
                    break;
            }
        }
        public async Task<T> side<T>(page<T> page)
        {
            dialog_page = page;
            set(page);
            TaskCompletionSource<T> rt = new TaskCompletionSource<T>();
            page.reply = rt.SetResult;
            api api = new api(page, c_run);
            stack.Children.Add(api.stack);
            api.z_focus();
            main_page.z_ui.IsEnabled = false;
            var dv = await rt.Task;
            dialog_page = null;
            main_page.z_ui.IsEnabled = true;
            z_focus();
            stack.Children.Remove(api.stack);
            return dv;
        }
        public async Task<T> dialog<T>(page<T> page)
        {
            dialog_page = page;
            set(page);
            TaskCompletionSource<T> rt = new TaskCompletionSource<T>();
            page.reply = rt.SetResult;
            main_page.z_ui.IsEnabled = false;
            Border border = new Border() { Background = color, CornerRadius = new CornerRadius(2), DataContext = page };
            api_ui.stage.Children.Add(border);
            border.Child = page.z_ui;
            page.start(this);
            page.focus();
            var dv = await rt.Task;
            dialog_page = null;
            api_ui.stage.Children.Remove(border);
            main_page.z_ui.IsEnabled = true;
            z_focus();
            return dv;
        }
        internal void z_focus()
        {
            if (dialog_page == null)
                main_page.focus();
            else
                dialog_page.focus();
        }
        public async Task<string> message(z_message.e_type e, string text, params string[] options)
        {
            z_message y = new z_message()
            {
                e = e,
                option = options,
                text = text,
            };
            return await dialog(y);
        }
    }
}
