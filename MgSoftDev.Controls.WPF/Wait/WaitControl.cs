using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MgSoftDev.Controls.WPF
{
    public class WaitControl : ContentControl
    {
        static WaitControl() { DefaultStyleKeyProperty.OverrideMetadata(typeof( WaitControl ), new FrameworkPropertyMetadata(typeof( WaitControl ))); }

        public WaitControl()
        {
           
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


        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(nameof( Fill ), typeof( Brush ), typeof( WaitControl ), new PropertyMetadata(default( Brush )));

        public Brush Fill { get { return ( Brush ) GetValue(FillProperty); } set { SetValue(FillProperty, value); } }

        public static readonly DependencyProperty ShapesGapProperty = DependencyProperty.Register(nameof( ShapesGap ), typeof( int ), typeof( WaitControl ), new PropertyMetadata(15));

        public int ShapesGap { get { return ( int ) GetValue(ShapesGapProperty); } set { SetValue(ShapesGapProperty, value); } }
        
        public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(nameof( Shapes ), typeof( int ), typeof( WaitControl ), new PropertyMetadata(15));

        public int Shapes { get { return ( int ) GetValue(ShapesProperty); } set { SetValue(ShapesProperty, value); } }
    }
}
