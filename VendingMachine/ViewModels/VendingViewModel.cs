using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace VendingMachineApp.ViewModels
{
    class VendingViewModel : BaseViewModel
    {
        public string LogInfo { get; set; }
        public VendingViewModel()
        {
            FirstCommand = new RelayCommand(FirstCommand_Execute, FirstCommand_CanExecute);
            SecondCommand = new RelayCommand(SecondCommand_Execute, SecondCommand_CanExecute);
            ThirdCommand = new RelayCommand(ThirdCommand_Execute, ThirdCommand_CanExecute);
            FourthCommand = new RelayCommand(FourthCommand_Execute, FourthCommand_CanExecute);
            ResetCommand = new RelayCommand(ResetCommand_Execute, ResetCommand_CanExecute);
            InsertCommand = new RelayCommand(InsertCommand_Execute, InsertCommand_CanExecute);
        }
        #region Commands
        public ICommand FirstCommand { get; set; }
        private bool FirstCommand_CanExecute(object parameter)
        {          
           return true;
        }
        private void FirstCommand_Execute(object parameter)
        {
            MessageBox.Show("Coca cola sold");
        }

        public ICommand SecondCommand { get; set; }
        private bool SecondCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void SecondCommand_Execute(object parameter)
        {
            MessageBox.Show("Water sold");
        }

        public ICommand ThirdCommand { get; set; }
        private bool ThirdCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void ThirdCommand_Execute(object parameter)
        {
            MessageBox.Show("Sprite sold");
        }

        public ICommand FourthCommand { get; set; }
        private bool FourthCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void FourthCommand_Execute(object parameter)
        {
            MessageBox.Show("Fanta sold");
        }
        public ICommand InsertCommand { get; set; }
        private bool InsertCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void InsertCommand_Execute(object parameter)
        {
            MessageBox.Show("Coin inserted");
        }
        public ICommand ResetCommand { get; set; }
        private bool ResetCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void ResetCommand_Execute(object parameter)
        {
            MessageBox.Show("Coins returned");
        }
        #endregion
    }
}
