using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MgSoftDev.Controls.WPF.MessageBox;
using MgSoftDev.Controls.WPF.Notification;

namespace MgSoftDev.Controls.Wpf.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NotifyService.Show(_=>_.Title("asas"));
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {

            MessageBoxDialog.ShowAsterisk("My Header", "My content");
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowError("My Header", "My content",_=>_.Width(1000).OkLabel("My OK"));
        }

        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowExclamation("My Header", "My content");
        }

        private void ButtonBase_OnClick4(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowHand("My Header", "My content");
        }

        private void ButtonBase_OnClick5(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowInformation("My Header", "My content");
        }

        private void ButtonBase_OnClick6(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowNone("My Header", "My content");
        }

        private void ButtonBase_OnClick7(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowQuestion("My Header", "My content");
        }

        private void ButtonBase_OnClick8(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowStop("My Header", "My content");
        }

        private void ButtonBase_OnClick9(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowSuccessful("My Header", "My content");
        }

        private void ButtonBase_OnClick10(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowWarning("My Header", "My content");
        }
    }
}
