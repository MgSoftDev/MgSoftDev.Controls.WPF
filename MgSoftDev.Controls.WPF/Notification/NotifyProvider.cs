using System;
using System.Composition;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace MgSoftDev.Controls.WPF.Notification
{
    [Export( "Default", typeof( INotify ) )]
    internal class NotifyProvider : INotify
    {
        #region Field

        private Window _Window;

        #endregion

        #region Ctor

        public NotifyProvider( )
        {
            Settings = new NotificationSettings()
                           {
                               FontSizeTitle     = 14,
                               FontSizeMessage   = 14,
                               FontFamilyTitle   = "Segoe UI",
                               FontFamilyMessage = "Segoe UI",
                               Type              = NotificationSettings.NotifyType.Success,
                               Position          = NotificationSettings.NotifyPosition.BottomRight,
                               Width             = 300,
                               Height            = 50,
                               Duration          = TimeSpan.FromSeconds( 10 )
                           };
        }

        #endregion

        #region Property

        public NotificationSettings Settings { get; set; }

        #endregion

        #region Method

        private void Add( Notification n )
        {
           // _Window.Activate();

            var item = new NotificationControl()
                           {
                               NotificationItem = n._Item
                           };

            if( n._Item.Position == NotificationSettings.NotifyPosition.TopLeft )
                ((StackPanel)_Window.FindName("TopLeft"))?.Children.Add( ( item ) );

            if( n._Item.Position == NotificationSettings.NotifyPosition.TopRight )
                ((StackPanel)_Window.FindName("TopRight"))?.Children.Add( item );

            if( n._Item.Position == NotificationSettings.NotifyPosition.BottomLeft )
                ((StackPanel)_Window.FindName("BottomLeft"))?.Children.Add( item );

            if( n._Item.Position == NotificationSettings.NotifyPosition.BottomRight )
                ((StackPanel)_Window.FindName("BottomRight"))?.Children.Add( item );

            item.NotificationClosed += async ( s, a )=>
            {
                await Task.Delay( TimeSpan.FromSeconds( 0.5 ) ).ConfigureAwait( true );
                var obj = ( NotificationControl ) s;
                obj.NotificationItem.ActionEndLife?.Invoke();

                if( obj.NotificationItem.Position == NotificationSettings.NotifyPosition.TopLeft )
                    ((StackPanel)_Window.FindName("TopLeft"))?.Children.Remove( obj );

                if( obj.NotificationItem.Position == NotificationSettings.NotifyPosition.TopRight )
                    ((StackPanel)_Window.FindName("TopRight"))?.Children.Remove( obj );

                if( obj.NotificationItem.Position == NotificationSettings.NotifyPosition.BottomLeft
                ) ((StackPanel)_Window.FindName("BottomLeft"))?.Children.Remove( obj );

                if( obj.NotificationItem.Position == NotificationSettings.NotifyPosition.BottomRight
                ) ((StackPanel)_Window.FindName("BottomRight"))?.Children.Remove( obj );

                obj = null;
                GC.Collect();
            };

            item.TimeLife();
        }


        private void CrearIfNotExist( )
        {
            Application.Current.Dispatcher.Invoke( new Action( ( )=>
            {
                if( _Window != null && _Window.IsLoaded ) return;
                 using var stream =
                    File.Open(Path.Combine(Environment.CurrentDirectory, @"Startup\NotificationView.xaml"),
                        FileMode.Open);
                
                var xmlReader = XmlReader.Create(stream);
                _Window = (Window)XamlReader.Load(xmlReader);
                stream.Dispose();
                
                _Window.ShowInTaskbar = false;

                _Window.StateChanged += ( s, a )=>
                {
                    if( _Window.WindowState != WindowState.Maximized )
                        _Window.WindowState = WindowState.Maximized;
                };

                Application.Current.MainWindow.Closed += ( s, a )=>_Window.Close();
                _Window.Show();
            } ) );
        }

        #region Implementation of INotify

        public void Show( Notification notification )
        {
            if( notification == null ) return;

            CrearIfNotExist();

            Application.Current.Dispatcher.Invoke( ( )=>
            {
                Add( notification );
            } );
        }

        public void Show( Action<Notification> configAction )
        {
            if( configAction == null ) return;

            CrearIfNotExist();

            Application.Current.Dispatcher.Invoke( ( )=>
            {
                var n = new Notification( Settings );
                configAction.Invoke( n );
                Add( n );
            } );
        }

        #endregion

        #endregion
    }
}
