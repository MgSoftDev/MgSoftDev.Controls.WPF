using System;

namespace MgSoftDev.Controls.WPF.Notification
{
    public static class NotifyService
    {
        internal static INotify _Notify = new NotifyProvider();

        public static void Show( Notification notification )=>_Notify.Show( notification._Item );

        public static void Show(Action<Notification> configAction)
        {
            if (configAction == null) return;

            var notification = new Notification();
            configAction.Invoke(notification);

            _Notify.Show(notification._Item);
        }
    }
}
