using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;

namespace MgSoftDev.Controls.WPF.MaterialTheme.Helpers.Extensions
{
    public static class DialogExt
    {
        public static async Task<object> ShowDialog<T>(this T ui, object dialogId = null, Action<T, DialogOpenedEventArgs> dialogOpenedAction = null,
                                                    Action<T, DialogClosingEventArgs> dialogClosingAction = null) where T : UIElement
        {
            var openAction = dialogOpenedAction == null ? null : new DialogOpenedEventHandler((s, a) => dialogOpenedAction(ui, a));
            var closingAction = dialogClosingAction == null ? null : new DialogClosingEventHandler((s, a) => dialogClosingAction(ui, a));

            if (Application.Current.Dispatcher.CheckAccess()) return await DialogHost.Show(ui, dialogId!, openAction!, closingAction!);

            return await await Application.Current.Dispatcher.InvokeAsync(() => DialogHost.Show(ui, dialogId!, openAction!, closingAction!));
        }



        public static async Task<object> ShowDialog<T>(this T ui, Action<T, DialogOpenedEventArgs> dialogOpenedAction) where T : UIElement
        { return await ShowDialog<T>(ui, null, dialogOpenedAction, null); }


        public static async Task<object> ShowDialog<T>(this T ui, Action<T, DialogOpenedEventArgs> dialogOpenedAction, Action<T, DialogClosingEventArgs> dialogClosingAction) where T : UIElement
        {
            return await ShowDialog<T>(ui, null, dialogOpenedAction, dialogClosingAction);
        }

        public static void CloseDialog(object dialogId = null, object parameter = null)
        {

            if (Application.Current.Dispatcher.CheckAccess())
            {
                if (DialogHost.IsDialogOpen(dialogId))
                    DialogHost.Close(dialogId, parameter);
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (DialogHost.IsDialogOpen(dialogId)) DialogHost.Close(dialogId, parameter);
                });
            }
        }

        public static void CloseDialog(string dialogId)
        {
            CloseDialog(dialogId, null);
        }

        public static void CloseDialog(object parameter)
        {
            CloseDialog(null, parameter);
        }

    }
}
