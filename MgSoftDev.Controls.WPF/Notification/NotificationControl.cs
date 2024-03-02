using System;
using System.Threading.Tasks;
using System.Windows;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationControl : System.Windows.Controls.Control
    {
        static NotificationControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationControl), new FrameworkPropertyMetadata(typeof(NotificationControl)));
        }

        public static readonly DependencyProperty NotificationItemProperty = DependencyProperty.Register(
            "NotificationItem", typeof(NotificationItem), typeof(NotificationControl), new PropertyMetadata(default(NotificationItem)));

        public NotificationItem NotificationItem { get { return (NotificationItem)GetValue(NotificationItemProperty); } set { SetValue(NotificationItemProperty, value); } }

        public static readonly RoutedEvent NotificationClosedEvent = EventManager.RegisterRoutedEvent(
            "NotificationClosed", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(NotificationControl));

        public event RoutedEventHandler NotificationClosed
        {
            add { AddHandler(NotificationClosedEvent, value); }
            remove { RemoveHandler(NotificationClosedEvent, value); }
        }

        public bool IsClose { get; private set; }
        public void Close()
        {
            if(IsClose) return;
            IsClose = true;
            RaiseEvent(new RoutedEventArgs(NotificationClosedEvent));
        }

        public async Task TimeLife()
        {
            if (NotificationItem.Duration == TimeSpan.Zero) return;
            await Task.Delay(NotificationItem.Duration).ConfigureAwait(true);
            if(IsClose) return;
            IsClose = true;
            RaiseEvent(new RoutedEventArgs(NotificationClosedEvent));
        }


    }
}
