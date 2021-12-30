using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Notify.ShowInformation("Mensaje de informacion","Como frutas y verduras");
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
            Task.Run(() => {
                MessageBoxDialog.ShowWarning("My Header", "My content");
            });
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = new Button()
                          {
                              Content = "Goto Meesage"
                          };
            btn.Click += Btn_Click;
            Notify.ShowSuccess("Mensaje de OK adasd asdada adasdasd", "Como frutas y verduras asmdasd adasd asdasda adasd asdasda  asd",_=>
                                   _.EndLifeAction(()=>MessageBoxDialog.ShowError("asas","asas")).ActionControl(btn)
                                    );
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxDialog.ShowWarning("ASAS", "AS");
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {

                new SolidColorBrush(Colors.Red);

                Notify.ShowWarning("Mensaje de WARN", "Como frutas y verduras", _ => _.ForegroundTitle(Brushes.Yellow).CustomIcon(Geometry.Parse(
                                                                                                                                      "M14,16.599994L14,19.300002 18,19.300002 18,16.599994z M13.899994,4.4999964L13.899994,13.49999 17.899994,13.49999 17.899994,4.4999964z M0,0L32,0 32,24.199992 11.100006,24.199992 5.2000122,31.899999 5.2000122,24.199992 0,24.199992z"),Brushes.BlueViolet,Brushes.Red));
            });
            
        }

        private void ButtonBase3_OnClick(object sender, RoutedEventArgs e)
        {
            Notify.ErrorGlobalConfig.Height = 300;
            Notify.ErrorGlobalConfig.FontSizeMessage = 20;

            Task.Run(()=>
            {

                Notify.ShowError("Mensaje de Error", "Como frutas y verduras",_=>_.MessageFontSize(10).Duration(TimeSpan.Zero));
            });
        }

        private  void ButtonBase_OnClick11(object sender, RoutedEventArgs e)
        {
            wait.Show = true;

            

        }

        private void ButtonBase_OnClick12(object sender, RoutedEventArgs e)
        {

            wait.Show = false;

        }
    }
}
