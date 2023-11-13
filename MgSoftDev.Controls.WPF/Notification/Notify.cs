using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MgSoftDev.Controls.WPF.Notification
{
    public static class Notify
    {
        static Notify()
        {
            

            InformationGlobalConfig = new NotificationGlobalConfig()
                                          {
                                              Background        = Brushes.RoyalBlue,
                                              ForegroundTitle   = Brushes.LightYellow,
                                              ForegroundMessage = Brushes.White,
                                              IconPath = Geometry.Parse(
                                                  "M14,16.599994L14,19.300002 18,19.300002 18,16.599994z M13.899994,4.4999964L13.899994,13.49999 17.899994,13.49999 17.899994,4.4999964z M0,0L32,0 32,24.199992 11.100006,24.199992 5.2000122,31.899999 5.2000122,24.199992 0,24.199992z"),
                                              IconFill = Brushes.LightGray
              
            };

            SuccessGlobalConfig = new NotificationGlobalConfig()
                                      {
                                          Background        = Brushes.ForestGreen,
                                          ForegroundTitle   = Brushes.LightYellow,
                                          ForegroundMessage = Brushes.White,
                                          IconPath          = Geometry.Parse("M27.903015,0L32,4.0970465 12.369019,23.728029 11.685974,24.520998 0,14.441042 3.7819824,10.054994 11.330017,16.567019z"),
                                          IconFill          = Brushes.LightGray
            };

            WarningGlobalConfig = new NotificationGlobalConfig()
                                      {
                                          Background        = Brushes.GreenYellow,
                                          ForegroundTitle   = Brushes.DarkSlateBlue,
                                          ForegroundMessage = Brushes.Black,
                                          IconPath = Geometry.Parse("M13.950004,24.5L13.950004,28.299988 17.950004,28.299988 17.950004,24.5z M13.950004,10.399963L13.950004,21.699951 17.950004,21.699951 17.950004,10.399963z M15.950004,0C16.349998,0,16.750007,0.19995117,16.950004,0.69995117L31.750011,30.099976C31.949993,30.5 31.949993,31 31.750011,31.399963 31.549999,31.799988 31.150005,32 30.750011,32L1.1499981,32C0.75000406,32 0.34999478,31.799988 0.14999761,31.399963 -0.049999204,31 -0.049999204,30.5 0.14999761,30.099976L14.950004,0.69995117C15.150001,0.19995117,15.549995,0,15.950004,0z"),
                                          IconFill = Brushes.Black
            };

            ErrorGlobalConfig = new NotificationGlobalConfig()
                                      {
                                          Background        = Brushes.DarkRed,
                                          ForegroundTitle   = Brushes.LightYellow,
                                          ForegroundMessage = Brushes.White,
                                         IconPath = Geometry.Parse("M5.1163335,0C6.4203386,-9.1704351E-08,7.7243743,0.4009941,8.7273803,1.4039678L16.150495,8.1248624 23.27359,1.704927C25.27963,-0.10003502 28.489671,-0.10003502 30.495712,1.704927 32.502731,3.5109269 32.502731,6.4198744 30.495712,8.2258736L23.373596,14.745721 30.094705,20.864637C32.100749,22.670576 32.100749,25.579523 30.094705,27.385523 28.088663,29.190485 24.878623,29.190485 22.871604,27.385523L16.150495,21.26563 9.1293941,27.585531C7.122345,29.39147 3.9123056,29.39147 1.9062939,27.585531 -0.099748187,25.780569 -0.099748187,22.870584 1.9062939,21.065622L8.9283719,14.745721 1.5052868,7.9248535C-0.50176227,6.1188537 -0.50176227,3.2099065 1.5052868,1.4039678 2.5082927,0.50200556 3.8122978,-9.1704351E-08 5.1163335,0z"),
                                         IconFill = Brushes.LightGray
            };
         
        }
        public enum NotificationPosition
        {
            TopLeft,
            TopRight,
            TopCenter,
            BottomLeft,
            BottomRight,
            BottomCenter,
        }

        public enum NotificationType
        {
            Information,
            Success,
            Warning,
            Error,
            Custom
        }

        private  static     NotificationView         _Window;
        public static NotificationGlobalConfig InformationGlobalConfig { get; private set; }
        public static NotificationGlobalConfig SuccessGlobalConfig     { get; private set; }
        public static NotificationGlobalConfig WarningGlobalConfig     { get; private set; }
        public static NotificationGlobalConfig ErrorGlobalConfig       { get; private set; }

        public static void ShowInformation(string title, string message, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(NotificationType.Information);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(() => ShowInternal(notify._Item));
        }

        public static void ShowSuccess(string title, string message, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(NotificationType.Success);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(()=>ShowInternal(notify._Item));
        }

        public static void ShowWarning(string title, string message, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(NotificationType.Warning);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(()=>ShowInternal(notify._Item));
        }
        public static void ShowError(string title, string message, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(NotificationType.Error);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(()=>ShowInternal(notify._Item));
        }


        public static void ShowCustom(string title, string message, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(NotificationType.Custom);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(() => ShowInternal(notify._Item));
        }
        public static void Show(string title, string message, NotificationType notificationType, Action<NotificationConfig> config = null)
        {
            var notify = new NotificationConfig(notificationType);
            notify.Title(title).Message(message);
            config?.Invoke(notify);

            Application.Current.Dispatcher.Invoke(() => ShowInternal(notify._Item));
        }

        private static void CrearIfNotExist()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_Window is { IsLoaded: true }) return;

                _Window = new NotificationView
                              {
                                  ShowInTaskbar = false
                              };

                _Window.StateChanged += (_, _) =>
                {
                    if (_Window.WindowState != WindowState.Maximized)
                        _Window.WindowState = WindowState.Maximized;
                };
                
               

                if( Application.Current.MainWindow != null )
                {
                    Application.Current.MainWindow.StateChanged += (s, e) =>
                    {
                        if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
                        {
                            _Window.Owner = null;
                            _Window.Show();
                        }
                        else 
                        {
                            _Window.Hide();
                            _Window.Owner = Application.Current.MainWindow;
                            _Window.Show();
                        }
                    };
                    Application.Current.MainWindow.Closed += (_, _)=>_Window.Close();
                }
                _Window.Owner = Application.Current.MainWindow;
                _Window.Show();
            });
        }

        private static void Add(NotificationItem notification)
        {
            // _Window.Activate();

            var item = new NotificationControl()
                           {
                               NotificationItem = notification
                           };

            switch (notification.Position)
            {
                case NotificationPosition.TopLeft:
                    _Window.TopLeft?.Children.Add(item);

                    break;
                case NotificationPosition.TopRight:
                    _Window.TopRight?.Children.Add(item);

                    break;
                case NotificationPosition.BottomLeft:
                    _Window.BottomLeft?.Children.Add(item);

                    break;
                case NotificationPosition.BottomRight:
                    _Window.BottomRight?.Children.Add(item);

                    break;
                case NotificationPosition.TopCenter:    _Window.TopCenter?.Children.Add(item); break;
                case NotificationPosition.BottomCenter: _Window.BottomCenter?.Children.Add(item); break;
                
            }

            item.NotificationClosed += async (s, _) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(true);
                var obj = (NotificationControl)s;
                obj.NotificationItem.ActionEndLife?.Invoke();

                switch (obj.NotificationItem.Position)
                {
                    case NotificationPosition.TopLeft:
                        _Window.TopLeft?.Children.Remove(obj);

                        break;
                    case NotificationPosition.TopRight:
                        _Window.TopRight?.Children.Remove(obj);

                        break;
                    case NotificationPosition.BottomLeft:
                        _Window.BottomLeft?.Children.Remove(obj);

                        break;
                    case NotificationPosition.BottomRight:
                        _Window.BottomRight?.Children.Remove(obj);

                        break;
                    case NotificationPosition.TopCenter:    _Window.TopCenter?.Children.Remove(obj); break;
                    case NotificationPosition.BottomCenter: _Window.BottomCenter?.Children.Remove(obj); break;
                    
                }

                GC.Collect();
            };

            item.TimeLife();
        }


        private static void ShowInternal(NotificationItem item)
        {
            if (item == null) return;

            CrearIfNotExist();

            Application.Current.Dispatcher.Invoke(() =>
            {
                Add(item);
            });
        }
    }
}
