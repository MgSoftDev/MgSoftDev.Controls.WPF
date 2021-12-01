using System;

namespace MgSoftDev.Controls.WPF.Notification
{
    public interface INotify
    {
        void Show( Notification         notification );
        void Show( Action<Notification> configAction );
    }
}
