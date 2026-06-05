using System.ComponentModel;
using System.Windows;

namespace MgSoftDev.Controls.WPF.Keyword;

public  class KeyboardHelper : DependencyObject
{

    public static  KeyboardControl Keyboard { get; set; }

    static KeyboardHelper()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
        Keyboard         = new KeyboardControl();
           
    }

    public static readonly DependencyProperty KeyboardScopeProperty =
        DependencyProperty.RegisterAttached("KeyboardScope",
                                            typeof(KeyboardControl.KeyboardScope), typeof(KeyboardHelper),
                                            new PropertyMetadata(default(KeyboardControl.KeyboardScope), KeyboardScopeChanged) );

    public static KeyboardControl.KeyboardScope GetKeyboardScope(DependencyObject obj)
    {
        return (KeyboardControl.KeyboardScope)obj.GetValue(KeyboardScopeProperty);
    }

    public static void SetKeyboardScope(DependencyObject obj, KeyboardControl.KeyboardScope value)
    {
        obj.SetValue(KeyboardScopeProperty, value);
    }



    private static void KeyboardScopeChanged(
        DependencyObject                   d,
        DependencyPropertyChangedEventArgs args )
    {
        var text = d as UIElement;

        if( text == null ) return;
            

        text.GotKeyboardFocus  -= Text_GotKeyboardFocus;
        text.LostKeyboardFocus -= Text_LostKeyboardFocus;
            
        text.GotKeyboardFocus  += Text_GotKeyboardFocus;
        text.LostKeyboardFocus += Text_LostKeyboardFocus;
    }

    private static void Text_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
    {
        Keyboard.Hide();

    }

    private static void Text_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
    {
        Keyboard.Show(GetKeyboardScope((UIElement)sender));
    }
}
