using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Net6PopupProblem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        ShellViewModel _vm;

        public ShellView()
        {
            InitializeComponent();
        }

		private void Popup_Closed(object sender, EventArgs e)
		{
			Application.Current?.Dispatcher.BeginInvoke(() => { dg.Focus(); }, DispatcherPriority.Background);
		}

		private void PopupPayment_Opened(object sender, EventArgs e)
		{
			Application.Current?.Dispatcher.BeginInvoke(() =>
			{
				tbSumPay.SelectAll();
				tbSumPay.Focus();
			}, DispatcherPriority.Background);
		}

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is ShellViewModel vm)
            {
                _vm = vm;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_vm != null && e.Key == Key.F5)
            {
                _vm.PopupsManager.PaymentIsOpen = true;
            }
        }

        private void OnPopupClose_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Popup popup = sender as Popup;
            popup.IsOpen = false;
            Application.Current?.Dispatcher.BeginInvoke(new Action(() => { dg.Focus(); }), DispatcherPriority.Render);
        }
    }
}
