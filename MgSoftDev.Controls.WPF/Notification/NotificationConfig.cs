using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public class NotificationConfig
    {
        internal readonly NotificationItem _Item;

        public NotificationConfig(Notify.NotificationType notificationType)
        {
            _Item = new NotificationItem();
            var globalConfig = Notify.SuccessGlobalConfig;

            switch ( notificationType )
            {
                case Notify.NotificationType.Information:
                    globalConfig = Notify.InformationGlobalConfig;

                    break;
                case Notify.NotificationType.Success:
                    globalConfig = Notify.SuccessGlobalConfig;

                    break;
                case Notify.NotificationType.Warning:
                    globalConfig = Notify.WarningGlobalConfig;

                    break;
                case Notify.NotificationType.Error:
                    globalConfig = Notify.ErrorGlobalConfig;

                    break;
                case Notify.NotificationType.Custom:
                    globalConfig = Notify.SuccessGlobalConfig;

                    break;
            }

            Duration(globalConfig.Duration);
            Position(globalConfig.Position);
            Width(globalConfig.Width);
            Height(globalConfig.Height);
            TitleFontSize(globalConfig.FontSizeTitle);
            TitleFont(globalConfig.FontFamilyTitle);
            MessageFontSize(globalConfig.FontSizeMessage);
            MessageFont(globalConfig.FontFamilyMessage);
            Background(globalConfig.Background);
            ForegroundTitle(globalConfig.ForegroundTitle);
            ForegroundMessage(globalConfig.ForegroundMessage);
            CustomIcon(globalConfig.IconPath, globalConfig.IconFill, globalConfig.IconStroke);
            Type(notificationType);
        }

        #region Fluent API

        public NotificationConfig EndLifeAction(Action action)
        {
            _Item.ActionEndLife = action;

            return this;
        }

        public NotificationConfig Title(string title)
        {
            _Item.Title = title;

            return this;
        }

        public NotificationConfig Message(string message)
        {
            _Item.Message = message;

            return this;
        }

        private void Type(Notify.NotificationType type)
        {
            _Item.Type = type;
            
        }

        public NotificationConfig Position(Notify.NotificationPosition position)
        {
            _Item.Position = position;

            return this;
        }

        public NotificationConfig Duration(TimeSpan duration)
        {
            _Item.Duration = duration;

            return this;
        }

        public NotificationConfig Width(double width)
        {
            _Item.Width = width;

            return this;
        }

        public NotificationConfig Height(double height)
        {
            _Item.Height = height;

            return this;
        }

        public NotificationConfig Background(Brush color)
        {
            _Item.Background = color;

            return this;
        }

        public NotificationConfig ForegroundTitle(Brush color)
        {
            _Item.ForegroundTitle = color;

            return this;
        }

        public NotificationConfig ForegroundMessage(Brush color)
        {
            _Item.ForegroundMessage = color;

            return this;
        }

        public NotificationConfig CustomIcon(Geometry path, Brush fill, Brush stroke)
        {
            _Item.IconPath = path;
            _Item.IconFill = fill;
            _Item.IconStroke = stroke;
            return this;
        }

        public NotificationConfig TitleFontSize(int size)
        {
            _Item.FontSizeTitle = size;

            return this;
        }

        public NotificationConfig MessageFontSize(int size)
        {
            _Item.FontSizeMessage = size;

            return this;
        }

        public NotificationConfig TitleFont(string fontName)
        {
            _Item.FontFamilyTitle = fontName;

            return this;
        }

        public NotificationConfig MessageFont(string fontName)
        {
            _Item.FontFamilyMessage = fontName;

            return this;
        }
        public NotificationConfig ActionControl(UIElement control)
        {
            _Item.ActionControl = control;

            return this;
        }

        #endregion
    }
}
