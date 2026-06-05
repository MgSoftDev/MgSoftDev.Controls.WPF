using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using MgSoftDev.Controls.WPF.Helpers;

namespace MgSoftDev.Controls.WPF.Keyword
{

    public class KeyboardControl : System.Windows.Controls.Control
    {
        public static bool _EnableTouch = false;
        static KeyboardControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof( KeyboardControl ),
                                                     new FrameworkPropertyMetadata(typeof( KeyboardControl )));
        }


        private Popup _Popup = new Popup();

        public KeyboardControl()
        {
            _Popup.StaysOpen      = true;
            _Popup.Child          = this;
            _Popup.Placement      = PlacementMode.Bottom;
            IniCommands();
            CapsLook = Convert.ToBoolean(NativeMethods.GetKeyState(( byte ) NativeMethods.KeyCode.CAPS_LOCK));


            IsVisibleChanged += (s, a)=>
            {
                if (( bool ) a.NewValue && !_EnableTouch) Hide();
            };
        }

        


        public enum KeyboardScope
        {
            None,
            Alphanumeric,
            Calculator,
            Numeric,
            Decimal
        }


        public static readonly DependencyProperty KeyPressCommandProperty = DependencyProperty.Register(
            "KeyPressCommand", typeof( DelegateCommand<string> ), typeof( KeyboardControl ), new PropertyMetadata(default( DelegateCommand<string> )));

        public DelegateCommand<string> KeyPressCommand
        {
            get { return ( DelegateCommand<string> ) GetValue(KeyPressCommandProperty); }
            set { SetValue(KeyPressCommandProperty, value); }
        }
        
        
        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(
            "CloseCommand", typeof( AsyncDelegateCommand ), typeof( KeyboardControl ), new PropertyMetadata(default( AsyncDelegateCommand )));

        public AsyncDelegateCommand CloseCommand
        {
            get { return ( AsyncDelegateCommand ) GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        

        public static readonly DependencyProperty ScopeProperty = DependencyProperty.Register(
            "Scope", typeof( KeyboardScope ), typeof( KeyboardControl ), new PropertyMetadata(default( KeyboardScope )));

        public KeyboardScope Scope
        {
            get { return ( KeyboardScope ) GetValue(ScopeProperty); }
            set { SetValue(ScopeProperty, value); }
        }

        public static readonly DependencyProperty CapsLookProperty = DependencyProperty.Register(
            "CapsLook", typeof( bool ), typeof( KeyboardControl ), new PropertyMetadata(default( bool )));

        public bool CapsLook
        {
            get { return ( bool ) GetValue(CapsLookProperty); }
            set { SetValue(CapsLookProperty, value); }
        }


        public static readonly DependencyProperty ChangeToNumericProperty = DependencyProperty.Register(
            "ChangeToNumeric", typeof( bool ), typeof( KeyboardControl ), new PropertyMetadata(default( bool )));

        public bool ChangeToNumeric
        {
            get { return ( bool ) GetValue(ChangeToNumericProperty); }
            set { SetValue(ChangeToNumericProperty, value); }
        }

        public static readonly DependencyProperty ChangeToNumericCommandProperty = DependencyProperty.Register(
            "ChangeToNumericCommand", typeof( DelegateCommand ), typeof( KeyboardControl ), new PropertyMetadata(default( DelegateCommand )));

        public DelegateCommand ChangeToNumericCommand
        {
            get { return ( DelegateCommand ) GetValue(ChangeToNumericCommandProperty); }
            set { SetValue(ChangeToNumericCommandProperty, value); }
        }

        #region Metodos

        void IniCommands()
        {
            KeyPressCommand = new DelegateCommand<string>(async s=>
            {
                if (s == "ChangeToNumeric")
                {
                    ChangeToNumeric = !ChangeToNumeric;

                    return;
                }

                if (s == "=")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_0);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "\"")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_2);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "#")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_3);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "$")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_4);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "%")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_5);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "&")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_6);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "(")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_8);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == ")")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.KEY_9);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }


                if (s == ">")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_102);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "[")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_7);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "]")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_2);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == "_")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_MINUS);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == ";")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_COMMA);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                if (s == ":")
                {
                    NativeMethods.SendKeyDown(NativeMethods.KeyCode.SHIFT);
                    NativeMethods.SendKeyPress(NativeMethods.KeyCode.OEM_PERIOD);
                    NativeMethods.SendKeyUp(NativeMethods.KeyCode.SHIFT);

                    return;
                }

                //NativeMethods.KeyCode.OEM_COMMA
                NativeMethods.KeyCode keyPress;
                Enum.TryParse(s, out keyPress);

                NativeMethods.SendKeyPress(keyPress);

                if (keyPress == NativeMethods.KeyCode.CAPS_LOCK)
                {
                    await Task.Delay(300);
                    CapsLook = Convert.ToBoolean(NativeMethods.GetKeyState(( byte ) NativeMethods.KeyCode.CAPS_LOCK));
                }
            });

            CloseCommand = new AsyncDelegateCommand(async ()=>
            {
                await Hide();
            });
            ChangeToNumericCommand = new DelegateCommand(()=>ChangeToNumeric = !ChangeToNumeric);
        }

        public async Task Show(bool autoPosition = true) { await Show(KeyboardScope.Alphanumeric, autoPosition); }

        public async Task Show(KeyboardScope scope, bool autoPosition = true)
        {
            if (!_EnableTouch) return;

            ChangeToNumeric = false;
            Scope           = scope;

            await Task.Delay(150);

            if (Application.Current.Dispatcher.CheckAccess())
            {
                // if (autoPosition) AutoAdjustmentPosition();
                _Popup.PlacementTarget = Keyboard.FocusedElement as UIElement;
                _Popup.IsOpen          = true;
            }
            else
                await Dispatcher.InvokeAsync(new Action(()=>
                {
                    // if (autoPosition) AutoAdjustmentPosition();
                    _Popup.PlacementTarget = Keyboard.FocusedElement as UIElement;
                    _Popup.IsOpen          = true;
                }));
        }

        public async Task Hide()
        {
            ChangeToNumeric = false;
            Scope           = KeyboardScope.Alphanumeric;
            if (Application.Current.Dispatcher.CheckAccess()) _Popup.IsOpen = false;
            else await Application.Current.Dispatcher.InvokeAsync(()=>_Popup.IsOpen = false);
        }

        void AutoAdjustmentPosition()
        {
            var element = Keyboard.FocusedElement as UIElement;
            var pos     = element.TranslatePoint(new Point(0, 0), Application.Current.MainWindow);

            var elemntEndPosition = pos.Y + element.RenderSize.Height;
            var posY              = ( ( Application.Current.MainWindow.RenderSize.Height - elemntEndPosition ) < RenderSize.Height ) ? pos.Y = pos.Y - RenderSize.Height : elemntEndPosition;
            var posX = ( pos.X + RenderSize.Width ) < Application.Current.MainWindow.RenderSize.Width
                           ? pos.X
                           : Application.Current.MainWindow.RenderSize.Width - RenderSize.Width;


            _Popup.RenderTransform = new TranslateTransform(posX, posY);
        }

        #endregion
    }
}
