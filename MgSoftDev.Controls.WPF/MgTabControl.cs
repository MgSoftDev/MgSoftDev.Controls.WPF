using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MgSoftDev.Controls.WPF
{
    public class MgTabControl: TabControl
    {
        static MgTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MgTabControl),
                                                     new FrameworkPropertyMetadata(typeof(MgTabControl)));



        }

        public static readonly DependencyProperty SelectBorderBrushProperty = DependencyProperty.Register("SelectBorderBrush",
                                                                                                          typeof(Brush),
                                                                                                          typeof(
                                                                                                              MgTabControl
                                                                                                          ));
        public Brush SelectBorderBrush
        {
            get { return (Brush)GetValue(SelectBorderBrushProperty); }
            set { SetValue(SelectBorderBrushProperty, value); }
        }


        public static readonly DependencyProperty TabBackgroundProperty = DependencyProperty.Register("TabBackground",
                                                                                                      typeof(Brush),
                                                                                                      typeof(
                                                                                                          MgTabControl
                                                                                                      ));
        public Brush TabBackground
        {
            get { return (Brush)GetValue(TabBackgroundProperty); }
            set { SetValue(TabBackgroundProperty, value); }
        }
        
    }
}
