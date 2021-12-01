using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationItem
    {
        public Action   ActionEndLife     { get; set; }
        public string   Title             { get; set; } = null;
        public string   Message           { get; set; } = null;
        public TimeSpan Duration          { get; set; } = TimeSpan.FromSeconds(10);
        public double   Width             { get; set; } = 300;
        public double   Height            { get; set; } = 100;
        public Brush    Background        { get; set; }
        public Brush    Foreground        { get; set; }
        public Path     Icon              { get; set; }
        public int      FontSizeTitle     { get; set; }
        public int      FontSizeMessage   { get; set; }
        public string   FontFamilyTitle   { get; set; }
        public string   FontFamilyMessage { get; set; }


        public NotificationSettings.NotifyType Type { get; set; } = NotificationSettings.NotifyType.Success;

        public NotificationSettings.NotifyPosition Position { get; set; } = NotificationSettings.NotifyPosition.BottomRight;
    }
}
