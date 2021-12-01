using System;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationSettings
    {
        public enum NotifyPosition
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }

        public enum NotifyType
        {
            Information,
            Success,
            Warning,
            Error,
            Custom
        }
        public int            FontSizeTitle     { get; set; }
        public int            FontSizeMessage   { get; set; }
        public double         Width             { get; set; }
        public double         Height            { get; set; }
        public NotifyType     Type              { get; set; }
        public NotifyPosition Position          { get; set; }
        public string         FontFamilyTitle   { get; set; }
        public string         FontFamilyMessage { get; set; }
        public TimeSpan       Duration          { get; set; }
    }
}
