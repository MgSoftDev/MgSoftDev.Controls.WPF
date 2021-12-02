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

        private NotificationView _Window;

        #endregion

        

        #region Method

        private void Add( NotificationItem notification )
        {
           // _Window.Activate();

            var item = new NotificationControl()
                           {
                               NotificationItem = notification
                           };

            switch ( notification.Position )
            {
                case NotificationItem.NotifyPosition.TopLeft:     _Window.TopLeft?.Children.Add(item);

                    break;
                case NotificationItem.NotifyPosition.TopRight:    _Window.TopRight?.Children.Add(item);

                    break;
                case NotificationItem.NotifyPosition.BottomLeft:  _Window.BottomLeft?.Children.Add(item);

                    break;
                case NotificationItem.NotifyPosition.BottomRight: _Window.BottomRight?.Children.Add(item);

                    break;
            }

            item.NotificationClosed += async ( s, a )=>
            {
                await Task.Delay( TimeSpan.FromSeconds( 0.5 ) ).ConfigureAwait( true );
                var obj = ( NotificationControl ) s;
                obj.NotificationItem.ActionEndLife?.Invoke();

                switch ( obj.NotificationItem.Position )
                {
                    case NotificationItem.NotifyPosition.TopLeft:     _Window.TopLeft?.Children.Remove( obj );

                        break;
                    case NotificationItem.NotifyPosition.TopRight:    _Window.TopRight?.Children.Remove( obj );

                        break;
                    case NotificationItem.NotifyPosition.BottomLeft:  _Window.BottomLeft?.Children.Remove( obj );

                        break;
                    case NotificationItem.NotifyPosition.BottomRight: _Window.BottomRight?.Children.Remove( obj );

                        break;
                }

                obj = null;
                GC.Collect();
            };

            item.TimeLife();
        }


        private void CrearIfNotExist( )
        {
            Application.Current.Dispatcher.Invoke( ( )=>
            {
                if( _Window is { IsLoaded: true } ) return;
               
                _Window = new NotificationView
                              {
                                  ShowInTaskbar = false
                              };

                _Window.StateChanged += ( _, _ )=>
                {
                    if( _Window.WindowState != WindowState.Maximized )
                        _Window.WindowState = WindowState.Maximized;
                };

                Application.Current.MainWindow.Closed += ( s, a )=>_Window.Close();
                _Window.Show();
            } );
        }

        #region Implementation of INotify

        public void Show( NotificationItem notification )
        {
            if( notification == null ) return;

            CrearIfNotExist();

            Application.Current.Dispatcher.Invoke( ( )=>
            {
                Add( notification );
            } );
        }
        
        #endregion

        #endregion
    }
}
