using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationGlobalConfig
    {
        public TimeSpan                    Duration          { get; set; } = TimeSpan.FromSeconds(10);
        public Notify.NotificationPosition Position          { get; set; } = Notify.NotificationPosition.BottomRight;
        public double                      Width             { get; set; } = 300;
        public double                      Height            { get; set; } = 50;
        public int                         FontSizeTitle     { get; set; } = 16;
        public int                         FontSizeMessage   { get; set; } = 14;
        public string                      FontFamilyTitle   { get; set; } = "Segoe UI";
        public string                      FontFamilyMessage { get; set; } = "Segoe UI";
        public Brush                       ForegroundTitle   { get; set; } = Brushes.White;
        public Brush                       ForegroundMessage { get; set; } = Brushes.White;
        public Brush                       Background        { get; set; }
        public Geometry                    IconPath          { get; set; }
        public Brush                       IconFill          { get; set; }
        public Brush                       IconStroke        { get; set; }
    }
}
