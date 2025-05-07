using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.MessageBox
{
    public static class MessageBoxDialog
    {
        public enum MessageBoxIcon
        {
            Custom,
            Error,
            Warning,
            Question,
            Information,
            Successful,
            
        }


        public static MessageBoxDialogGlobalConfig GlobalConfig { get; private set; } = new MessageBoxDialogGlobalConfig()
                                                                                            {
                                                                                                Width       = 600,
                                                                                                CancelLabel = "CANCEL",
                                                                                                NotLabel    = "NO",
                                                                                                OkLabel     = "OK",
                                                                                                YesLabel    = "YES"
                                                                                            };


        public static MessageBoxResult ShowNone(string header, string content = null, Path customIconPath = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).CustomIcon(customIconPath).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Custom);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }

        public static MessageBoxResult ShowError(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Error);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }


        public static MessageBoxResult ShowWarning(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Warning);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }

        public static MessageBoxResult ShowQuestion(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.YesNo).Icon(MessageBoxIcon.Question);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }

        public static MessageBoxResult ShowInformation(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Information);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }

        public static MessageBoxResult ShowSuccessful(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Successful);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }

        

        

        

       

        public static MessageBoxResult Show(string header, string content = null, Action<MessageBoxDialogConfig> config = null)
        {
            var msj = new MessageBoxDialogConfig();
            msj.Header(header).Content(content).Buttons(MessageBoxButton.OK).Icon(MessageBoxIcon.Custom);
            config?.Invoke(msj);

            return Application.Current.Dispatcher.Invoke(()=>ShowInternal(msj._Item));
        }


        private static MessageBoxResult ShowInternal(MessageBoxDialogItem item)
        {
            MessageBoxResult result = MessageBoxResult.Cancel;


            var win = new Window
                          {
                              Background            = Brushes.Transparent,
                              AllowsTransparency    = true,
                              Focusable             = false,
                              ResizeMode            = ResizeMode.NoResize,
                              Topmost               = true,
                              WindowStartupLocation = WindowStartupLocation.CenterOwner,
                              WindowState           = WindowState.Normal,
                              WindowStyle           = WindowStyle.None,
                              ShowInTaskbar         = false,
                          };

           
            win.Loaded += (_, _)=>
            {
                win.Top = 1;

                item.LoadAction?.Invoke();
            };


            win.Content = new MessageBoxDialogControl
                              {
                                  VerticalAlignment   = VerticalAlignment.Center,
                                  HorizontalAlignment = HorizontalAlignment.Center,
                                  Header              = item.Header,
                                  Content             = item.Content,
                                  Buttons             = item.Buttons,
                                  Icon                = item.Icon,
                                  CustomIcon          = item.CustomIcon,
                                  Width               = item.Width,
                                  CancelLabel         = item.CancelLabel,
                                  NotLabel            = item.NotLabel,
                                  OkLabel             = item.OkLabel,
                                  YesLabel            = item.YesLabel,
                                  YesAction = ()=>
                                  {
                                      result = item.Buttons is MessageBoxButton.OK or MessageBoxButton.OKCancel ? MessageBoxResult.OK : result = MessageBoxResult.Yes;

                                      win.Close();
                                  },
                                  NotAction = ()=>
                                  {
                                      result = MessageBoxResult.No;
                                      win.Close();
                                  },
                                  CancelAction = ()=>
                                  {
                                      result = MessageBoxResult.Cancel;
                                      win.Close();
                                  }
                              };
            win.Owner = Application.Current.MainWindow;
            win.ShowDialog();
           
            return result;
        }
    }
}
