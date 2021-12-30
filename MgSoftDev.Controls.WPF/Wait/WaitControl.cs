using System.Windows;
using System.Windows.Controls;

namespace MgSoftDev.Controls.WPF
{
    public class WaitControl : ContentControl
    {
        static WaitControl() { DefaultStyleKeyProperty.OverrideMetadata(typeof( WaitControl ), new FrameworkPropertyMetadata(typeof( WaitControl ))); }

        public WaitControl()
        {
            ShowContent = new WaitProgressAnimationControl();
        }


        public static readonly DependencyProperty ShowProperty = DependencyProperty.Register(
            "Show", typeof( bool ), typeof( WaitControl ), new PropertyMetadata(default( bool )));

        public bool Show
        {
            get { return ( bool ) GetValue(ShowProperty); }
            set { SetValue(ShowProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof( string ), typeof( WaitControl ), new PropertyMetadata(default( string )));

        public string Text
        {
            get { return ( string ) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ShowContentProperty =
            DependencyProperty.Register("ShowContent", typeof( FrameworkElement ), typeof( WaitControl ), new PropertyMetadata(default( FrameworkElement )));

        public FrameworkElement ShowContent
        {
            get { return ( FrameworkElement ) GetValue(ShowContentProperty); }
            set { SetValue(ShowContentProperty, value); }
        }
    }
}
