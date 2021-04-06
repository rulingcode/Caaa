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
        List<Border> borders = new List<Border>();
        SolidColorBrush color = new SolidColorBrush(Color.FromArgb(70, 0, 0, 0));
        public api(page page)
        {
            stack.Children.Add(api_ui);
            main_page = page;
            api_ui.stage.Children.Add(page.z_ui);
            page.start(this);
        }
        public async Task<T> side<T>(page<T> page)
        {
            TaskCompletionSource<T> rt = new TaskCompletionSource<T>();
            page.reply = rt.SetResult;
            api api = new api(page);
            stack.Children.Add(api.stack);
            api.z_focus();
            var dv = await rt.Task;
            z_focus();
            stack.Children.Remove(api.stack);
            return dv;
        }
        public async Task<T> dialog<T>(page<T> page, bool background = false)
        {
            TaskCompletionSource<T> rt = new TaskCompletionSource<T>();
            page.reply = rt.SetResult;
            if (borders.Count == 0)
                main_page.z_ui.IsEnabled = false;
            else
                borders.Last().IsEnabled = false;
            borders.Add(new Border() { Background = background ? Brushes.White : color, CornerRadius = new CornerRadius(2), DataContext = page });
            api_ui.stage.Children.Add(borders.Last());
            borders.Last().Child = page.z_ui;
            page.start(this);
            page.focus();
            var dv = await rt.Task;
            api_ui.stage.Children.Remove(borders.Last());
            borders.Remove(borders.Last());
            if (borders.Count == 0)
                main_page.z_ui.IsEnabled = true;
            else
                borders.Last().IsEnabled = true;
            z_focus();
            return dv;
        }
        internal void z_focus()
        {
            if (borders.Count == 0)
                main_page.focus();
            else
                (borders.Last().DataContext as page).focus();
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
