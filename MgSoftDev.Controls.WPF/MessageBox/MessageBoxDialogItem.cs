using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.MessageBox
{
    internal class MessageBoxDialogItem : MessageBoxDialogGlobalConfig
    {
        public object                          Header      { get; set; }
        public object                          Content     { get; set; }
        public MessageBoxButton                Buttons     { get; set; }
        public MessageBoxDialog.MessageBoxIcon Icon        { get; set; }
        public Path                            CustomIcon  { get; set; }
        public Action                          LoadAction  { get; set; }
        
    }
}
