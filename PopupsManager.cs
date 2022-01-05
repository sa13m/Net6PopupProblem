using Prism.Mvvm;
using System;
using System.Windows;

namespace Net6PopupProblem
{
	public class PopupsManager : BindableBase
	{
		#region PaymentIsOpen
		private bool _paymentIsOpen;
		public bool PaymentIsOpen
		{
			get => _paymentIsOpen;
			set
			{
				try
				{
					SetProperty(ref _paymentIsOpen, value);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					_paymentIsOpen = false;
				}
			}
		}
		#endregion


		#region Title
		private string _title;
		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}
		#endregion
	}
}
