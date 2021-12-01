using System;

namespace MgSoftDev.Controls.WPF.Notification
{
    public static class NotifyService
    {
        internal static INotify _Notify;

        public static void Show( Notification notification )=>_Notify.Show( notification );

        public static void Show( Action<Notification> configAction )=>_Notify.Show( configAction );
    }
}
