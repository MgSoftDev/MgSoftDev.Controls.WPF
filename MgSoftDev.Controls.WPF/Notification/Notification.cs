using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class Notification
    {
        internal readonly NotificationItem _Item;


        public Notification()
        {
            _Item = new NotificationItem()
            {
                Title             = null,
                Message           = null,
                Type              = NotificationItem.NotifyType.Success,
                Position          = NotificationItem.NotifyPosition.BottomRight,
                Duration          = TimeSpan.FromSeconds(10),
                Width             = 300,
                Height            = 50,
                FontSizeTitle     = 14,
                FontSizeMessage   = 14,
                FontFamilyTitle   = "Segoe UI",
                FontFamilyMessage = "Segoe UI",
            };

            Type(NotificationItem.NotifyType.Success);
        }
        

        #region Fluent API

        public Notification EndLifeAction(Action action)
        {
            _Item.ActionEndLife = action;

            return this;
        }

        public Notification Title(string title)
        {
            _Item.Title = title;
            return this;
        }

        public Notification Message(string message)
        {
            _Item.Message = message;
            return this;
        }

        public Notification Type(NotificationItem.NotifyType type)
        {
            _Item.Type = type;

            _Item.Icon = new Path()
                             {
                                 Width   = 32,
                                 Height  = 32,
                                 Margin  = new Thickness(10, 5, 5, 5),
                                 Stretch = Stretch.Uniform,
                                 Fill    = Brushes.LightGray,
                             };

            if (type == NotificationItem.NotifyType.Success)
            {
                _Item.Background = new SolidColorBrush(Colors.ForestGreen);
                _Item.Foreground = new SolidColorBrush(Colors.White);
                _Item.Icon.Data  = Geometry.Parse("M27.903015,0L32,4.0970465 12.369019,23.728029 11.685974,24.520998 0,14.441042 3.7819824,10.054994 11.330017,16.567019z");
            }
            else if (type == NotificationItem.NotifyType.Error)
            {
                _Item.Background = new SolidColorBrush(Colors.DarkRed);
                _Item.Foreground = new SolidColorBrush(Colors.White);
                _Item.Icon.Data = Geometry.Parse("M5.1163335,0C6.4203386,-9.1704351E-08,7.7243743,0.4009941,8.7273803,1.4039678L16.150495,8.1248624 23.27359,1.704927C25.27963,-0.10003502 28.489671,-0.10003502 30.495712,1.704927 32.502731,3.5109269 32.502731,6.4198744 30.495712,8.2258736L23.373596,14.745721 30.094705,20.864637C32.100749,22.670576 32.100749,25.579523 30.094705,27.385523 28.088663,29.190485 24.878623,29.190485 22.871604,27.385523L16.150495,21.26563 9.1293941,27.585531C7.122345,29.39147 3.9123056,29.39147 1.9062939,27.585531 -0.099748187,25.780569 -0.099748187,22.870584 1.9062939,21.065622L8.9283719,14.745721 1.5052868,7.9248535C-0.50176227,6.1188537 -0.50176227,3.2099065 1.5052868,1.4039678 2.5082927,0.50200556 3.8122978,-9.1704351E-08 5.1163335,0z");
            }
            else if (type == NotificationItem.NotifyType.Warning)
            {
                _Item.Background = new SolidColorBrush(Colors.GreenYellow);
                _Item.Foreground = new SolidColorBrush(Colors.Black);
                _Item.Icon.Data = Geometry.Parse("M13.950004,24.5L13.950004,28.299988 17.950004,28.299988 17.950004,24.5z M13.950004,10.399963L13.950004,21.699951 17.950004,21.699951 17.950004,10.399963z M15.950004,0C16.349998,0,16.750007,0.19995117,16.950004,0.69995117L31.750011,30.099976C31.949993,30.5 31.949993,31 31.750011,31.399963 31.549999,31.799988 31.150005,32 30.750011,32L1.1499981,32C0.75000406,32 0.34999478,31.799988 0.14999761,31.399963 -0.049999204,31 -0.049999204,30.5 0.14999761,30.099976L14.950004,0.69995117C15.150001,0.19995117,15.549995,0,15.950004,0z");
                _Item.Icon.Fill = Brushes.Black;
            }
            else if (type == NotificationItem.NotifyType.Information)
            {
                _Item.Background = new SolidColorBrush(Colors.RoyalBlue);
                _Item.Foreground = new SolidColorBrush(Colors.White);
                _Item.Icon.Data = Geometry.Parse("M14,16.599994L14,19.300002 18,19.300002 18,16.599994z M13.899994,4.4999964L13.899994,13.49999 17.899994,13.49999 17.899994,4.4999964z M0,0L32,0 32,24.199992 11.100006,24.199992 5.2000122,31.899999 5.2000122,24.199992 0,24.199992z");
            }
            return this;
        }

        public Notification Position(NotificationItem.NotifyPosition position)
        {
            _Item.Position = position;
            return this;
        }

        public Notification Duration(TimeSpan duration)
        {
            _Item.Duration = duration;
            return this;
        }

        public Notification Width(double width)
        {
            _Item.Width = width;
            return this;
        }

        public Notification Height(double height)
        {
            _Item.Height = height;
            return this;
        }

        public Notification Background(Color color)
        {
            _Item.Background = new SolidColorBrush(color);
            return this;
        }

        public Notification Foreground(Color color)
        {
            _Item.Foreground = new SolidColorBrush(color);
            return this;
        }

        public Notification CustomIcon(Path path)
        {
            _Item.Icon = path;
            return this;
        }


        public Notification TitleFontSize(int size)
        {
            _Item.FontSizeTitle = size;
            return this;
        }
        public Notification MessageFontSize(int size)
        {
            _Item.FontSizeMessage = size;
            return this;
        }

        public Notification TitleFont(string fontName)
        {
            _Item.FontFamilyTitle = fontName;
            return this;
        }

        public Notification MessageFont(string fontName)
        {
            _Item.FontFamilyMessage = fontName;
            return this;
        }

        #endregion

    }
}
