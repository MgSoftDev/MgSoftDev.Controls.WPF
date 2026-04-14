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

        public static readonly DependencyProperty WidthIndicatorProperty = DependencyProperty.Register(nameof( WidthIndicator ), typeof( double ), typeof( WaitControl ), new PropertyMetadata(default( double )));

        public double WidthIndicator { get { return ( double ) GetValue(WidthIndicatorProperty); } set { SetValue(WidthIndicatorProperty, value); } }

        public static readonly DependencyProperty HeightIndicatorProperty = DependencyProperty.Register(nameof( HeightIndicator ), typeof( double ), typeof( WaitControl ), new PropertyMetadata(default( double )));

        public double HeightIndicator { get { return ( double ) GetValue(HeightIndicatorProperty); } set { SetValue(HeightIndicatorProperty, value); } }

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

        public static readonly DependencyProperty TextForegroundProperty = DependencyProperty.Register(nameof( TextForeground ), typeof( Brush ), typeof( WaitControl ), new PropertyMetadata(default( Brush )));

        public Brush TextForeground { get { return ( Brush ) GetValue(TextForegroundProperty); } set { SetValue(TextForegroundProperty, value); } }

        public static readonly DependencyProperty PanelBackgroundProperty = DependencyProperty.Register(nameof( PanelBackground ), typeof( Brush ), typeof( WaitControl ), new PropertyMetadata(default( Brush )));

        public Brush PanelBackground { get { return ( Brush ) GetValue(PanelBackgroundProperty); } set { SetValue(PanelBackgroundProperty, value); } }
        
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
