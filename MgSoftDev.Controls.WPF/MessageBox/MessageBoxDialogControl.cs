using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using MgSoftDev.Controls.WPF.MVVM;

namespace MgSoftDev.Controls.WPF.MessageBox
{
   
    public class MessageBoxDialogControl : Control
    {
        static MessageBoxDialogControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxDialogControl), new FrameworkPropertyMetadata(typeof(MessageBoxDialogControl)));
        }


        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof( object ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( object )));

        public object Header
        {
            get=>( object )GetValue(HeaderProperty);
            set=>SetValue(HeaderProperty, value);
        }


        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof( object ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( object )));

        public object Content
        {
            get=>( object )GetValue(ContentProperty);
            set=>SetValue(ContentProperty, value);
        }

        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof( MessageBoxButton ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( MessageBoxButton )));

        public MessageBoxButton Buttons
        {
            get=>( MessageBoxButton )GetValue(ButtonsProperty);
            set=>SetValue(ButtonsProperty, value);
        }


        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof( MessageBoxDialog.MessageBoxIcon ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( MessageBoxDialog.MessageBoxIcon )));

        public MessageBoxDialog.MessageBoxIcon Icon
        {
            get=>( MessageBoxDialog.MessageBoxIcon )GetValue(IconProperty);
            set=>SetValue(IconProperty, value);
        }


        public static readonly DependencyProperty CustomIconProperty = DependencyProperty.Register("CustomIcon", typeof( Path ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( Path )));

        public Path CustomIcon
        {
            get=>( Path )GetValue(CustomIconProperty);
            set=>SetValue(CustomIconProperty, value);
        }


        public static readonly DependencyProperty CancelActionProperty = DependencyProperty.Register("CancelAction", typeof( Action ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( Action )));

        public Action CancelAction
        {
            get { return ( Action )GetValue(CancelActionProperty); }
            set { SetValue(CancelActionProperty, value); }
        }

        public static readonly DependencyProperty YesActionProperty = DependencyProperty.Register("YesAction", typeof( Action ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( Action )));

        public Action YesAction
        {
            get { return ( Action )GetValue(YesActionProperty); }
            set { SetValue(YesActionProperty, value); }
        }

        public static readonly DependencyProperty NotActionProperty = DependencyProperty.Register("NotAction", typeof( Action ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( Action )));

        public Action NotAction
        {
            get { return ( Action )GetValue(NotActionProperty); }
            set { SetValue(NotActionProperty, value); }
        }


        public static readonly DependencyProperty OkLabelProperty = DependencyProperty.Register("OkLabel", typeof( string ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( string )));

        public string OkLabel
        {
            get { return ( string )GetValue(OkLabelProperty); }
            set { SetValue(OkLabelProperty, value); }
        }

        public static readonly DependencyProperty CancelLabelProperty = DependencyProperty.Register("CancelLabel", typeof( string ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( string )));

        public string CancelLabel
        {
            get { return ( string )GetValue(CancelLabelProperty); }
            set { SetValue(CancelLabelProperty, value); }
        }

        public static readonly DependencyProperty YesLabelProperty = DependencyProperty.Register("YesLabel", typeof( string ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( string )));

        public string YesLabel
        {
            get { return ( string )GetValue(YesLabelProperty); }
            set { SetValue(YesLabelProperty, value); }
        }

        public static readonly DependencyProperty NotLabelProperty = DependencyProperty.Register("NotLabel", typeof( string ), typeof( MessageBoxDialogControl ), new PropertyMetadata(default( string )));

        public string NotLabel
        {
            get { return ( string )GetValue(NotLabelProperty); }
            set { SetValue(NotLabelProperty, value); }
        }










        public void Yes()=>YesAction?.Invoke();
        public void Cancel()=>CancelAction?.Invoke();
        public void Not()=>NotAction?.Invoke();


    }
}
