using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationItem : NotificationGlobalConfig
    {
        public Action                  ActionEndLife { get; set; }
        public string                  Title         { get; set; } = null;
        public string                  Message       { get; set; } = null;
        public UIElement               ActionControl       { get; set; }
        public Notify.NotificationType Type          { get; set; } = Notify.NotificationType.Success;
    }
}
