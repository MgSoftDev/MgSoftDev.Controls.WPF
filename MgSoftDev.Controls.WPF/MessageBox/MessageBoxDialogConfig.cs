using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.MessageBox
{
    public class MessageBoxDialogConfig
    {
        internal readonly MessageBoxDialogItem _Item;


        public MessageBoxDialogConfig()
        {
            _Item = new MessageBoxDialogItem()
                        {
                            Header      = "",
                            Content     = "",
                            Buttons     = MessageBoxButton.OK,
                            Icon        = MessageBoxDialog.MessageBoxIcon.Custom,
                            Width       = MessageBoxDialog.GlobalConfig.Width,
                            CancelLabel = MessageBoxDialog.GlobalConfig.CancelLabel,
                            NotLabel    = MessageBoxDialog.GlobalConfig.NotLabel,
                            OkLabel     = MessageBoxDialog.GlobalConfig.OkLabel,
                            YesLabel    = MessageBoxDialog.GlobalConfig.YesLabel
                        };
        }
        public MessageBoxDialogConfig Header(string ui)
        {
            _Item.Header = ui;

            return this;
        }
        public MessageBoxDialogConfig Content(string ui)
        {
            _Item.Content = ui;

            return this;
        }
        public MessageBoxDialogConfig Header(UIElement ui)
        {
            _Item.Header = ui;

            return this;
        }
        public MessageBoxDialogConfig Content(UIElement ui)
        {
            _Item.Content = ui;

            return this;
        }

        public MessageBoxDialogConfig Buttons(MessageBoxButton buttons)
        {
            _Item.Buttons = buttons;

            return this;
        }

        public MessageBoxDialogConfig Icon(MessageBoxDialog.MessageBoxIcon icon)
        {
            _Item.Icon = icon;

            return this;
        }

        public MessageBoxDialogConfig CustomIcon(Path customIcon)
        {
            _Item.CustomIcon = customIcon;

            return this;
        }


        public MessageBoxDialogConfig Width(double width)
        {
            _Item.Width = width;

            return this;
        }
        public MessageBoxDialogConfig CancelLabel(string label)
        {
            _Item.CancelLabel = label;

            return this;
        }

        public MessageBoxDialogConfig NotLabel(string label)
        {
            _Item.NotLabel = label;

            return this;
        }
        public MessageBoxDialogConfig OkLabel(string label)
        {
            _Item.OkLabel = label;

            return this;
        }
        public MessageBoxDialogConfig YesLabel(string label)
        {
            _Item.YesLabel = label;

            return this;
        }
        public MessageBoxDialogConfig LoadAction(Action loadAction)
        {
            _Item.LoadAction = loadAction;

            return this;
        }



    }
}
