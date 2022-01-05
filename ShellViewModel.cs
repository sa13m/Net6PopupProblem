using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6PopupProblem
{
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel()
        {
            _popupsManager = new PopupsManager
            {
                Title = "Pay menu"
            };

            PayCommand = new DelegateCommand(ExecutePayCommand, CanExecuteSaveCommand).ObservesProperty(() => Sum);
        }

        #region PopupsManager
        private PopupsManager _popupsManager;
        public PopupsManager PopupsManager
        {
            get => _popupsManager;
            set => SetProperty(ref _popupsManager, value);
        }
        #endregion //PopupsOpened

        #region Sum
        private decimal _sum;
        public decimal Sum
        {
            get => _sum;
            set => SetProperty(ref _sum, value);
        }
        #endregion //Sum


        #region PayCommand
        public DelegateCommand PayCommand { get; set; }
        public void ExecutePayCommand()
        {
            _popupsManager.PaymentIsOpen = false;
        }

        public virtual bool CanExecuteSaveCommand()
        {
            return Sum > 0;
        }
        #endregion //PayCommand
    }
}
