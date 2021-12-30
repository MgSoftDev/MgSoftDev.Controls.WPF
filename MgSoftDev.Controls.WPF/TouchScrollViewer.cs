using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MgSoftDev.Controls.WPF
{
    public class TouchScrollViewer : ScrollViewer
    {
        static TouchScrollViewer() { DefaultStyleKeyProperty.OverrideMetadata(typeof( TouchScrollViewer ), new FrameworkPropertyMetadata(typeof( TouchScrollViewer ))); }

        public static readonly DependencyProperty IsTouchEnableProperty = DependencyProperty.Register("IsTouchEnable", typeof( bool ), typeof( TouchScrollViewer ), new PropertyMetadata(true));

        public bool IsTouchEnable
        {
            get=>( bool )GetValue(IsTouchEnableProperty);
            set=>SetValue(IsTouchEnableProperty, value);
        }

        private double _Velocity = 80;
        private Point  _ScrollStartPoint;
        private Point  _ScrollStartOffset;

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if( IsTouchEnable )
            {
                Cursor = Cursors.Arrow;
                ReleaseMouseCapture();
            }

            base.OnMouseLeave(e);
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if( IsMouseOver && IsTouchEnable )
            {
                // Save starting point, used later when determining 
                //how much to scroll.
                _ScrollStartPoint    = e.GetPosition(this);
                _ScrollStartOffset.X = HorizontalOffset;
                _ScrollStartOffset.Y = VerticalOffset;

                // Update the cursor if can scroll or not.
                Cursor = ( ExtentWidth > ViewportWidth ) || ( ExtentHeight > ViewportHeight ) ? Cursors.ScrollAll : Cursors.Arrow;
            }

            base.OnPreviewMouseDown(e);
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if( IsTouchEnable && Cursor == Cursors.ScrollAll )
                if( IsMouseOver )
                {
                    // Get the new scroll position.
                    Point point = e.GetPosition(this);

                    // Determine the new amount to scroll.
                    if( Math.Abs(point.X - _ScrollStartPoint.X) <= 20 && Math.Abs(point.Y - _ScrollStartPoint.Y) <= 20 ) return;

                    Point delta = new Point(( point.X > _ScrollStartPoint.X ) ? -( point.X - _ScrollStartPoint.X + _Velocity ) : ( _ScrollStartPoint.X - point.X + _Velocity ),
                                            ( point.Y > _ScrollStartPoint.Y ) ? -( point.Y - _ScrollStartPoint.Y + _Velocity ) : ( _ScrollStartPoint.Y - point.Y + _Velocity ));

                    // Scroll to the new position.
                    ScrollToHorizontalOffset(_ScrollStartOffset.X + delta.X);
                    ScrollToVerticalOffset(_ScrollStartOffset.Y   + delta.Y);
                    this.CaptureMouse();
                }

            base.OnPreviewMouseMove(e);
        }


        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            if( IsTouchEnable )
            {
                Cursor = Cursors.Arrow;
                ReleaseMouseCapture();
            }

            base.OnPreviewMouseUp(e);
        }
    }
}
