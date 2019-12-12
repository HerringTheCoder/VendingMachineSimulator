using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using VendingMachineApp.Models;


namespace VendingMachineApp.ViewModels
{
    class VendingViewModel : BaseViewModel
    {
        #region Binded Fields    
        private string _creditInfo;
        public string CreditInfo
        {
            get => _creditInfo;
            set
            {
                _creditInfo = value;
                OnPropertyChanged("CreditInfo");
            }
        }
        public KeyValuePair<string, Coin> SelectedCoin { get; set; } = new KeyValuePair<string, Coin>("5zł", new Coin(5.0m));

        private VendingMachine _vmachine = new VendingMachine();
        public VendingMachine VMachine
        {
            get => _vmachine;
            set {
                _vmachine = value;
               OnPropertyChanged("VMachine");                
            }
        }
        private decimal _credit;
        public decimal Credit
        {
            get => _credit;
            set
            {
                _credit = value;
                CreditInfo = "Credit: " + value;
                OnPropertyChanged("Credit");                             
            }
            
        }       
        public Dictionary<string, Coin> AcceptedCoins { get; set; } = new Dictionary<string, Coin>();
        #endregion

        #region Constructor
        public VendingViewModel()
        {
            FirstCommand = new RelayCommand(FirstCommand_Execute, FirstCommand_CanExecute);
            SecondCommand = new RelayCommand(SecondCommand_Execute, SecondCommand_CanExecute);
            ThirdCommand = new RelayCommand(ThirdCommand_Execute, ThirdCommand_CanExecute);
            FourthCommand = new RelayCommand(FourthCommand_Execute, FourthCommand_CanExecute);
            ResetCommand = new RelayCommand(ResetCommand_Execute, ResetCommand_CanExecute);
            InsertCommand = new RelayCommand(InsertCommand_Execute, InsertCommand_CanExecute);
            AcceptedCoins.Add("5zł", new Coin(5.0m));
            AcceptedCoins.Add("2zł", new Coin(2.0m));
            AcceptedCoins.Add("1zł", new Coin(1.0m));
            AcceptedCoins.Add("50gr", new Coin(0.5m));
            AcceptedCoins.Add("20gr", new Coin(0.2m));
            AcceptedCoins.Add("10gr", new Coin(0.1m));
            VMachine.Log = "Welcome to our vending machine! Choose your coin, confirm it with 'Add' button and choose your desired product.";
            CreditInfo = "Credit: 0.00";
        }
        #endregion

        #region Action Commands
        public ICommand InsertCommand { get; set; }
        private bool InsertCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void InsertCommand_Execute(object parameter)
        {
            decimal InsertedCoinValue = SelectedCoin.Value.Value;
            VMachine.InsertCoin(InsertedCoinValue);
            VMachine.Log = (InsertedCoinValue < 1.0m) ? "Added "+ Convert.ToInt32(InsertedCoinValue*100)+"gr" : "Added " + Convert.ToInt32(InsertedCoinValue) + "zł";
            CreditInfo = "Credit: " + VMachine.Credit;
            Debug.WriteLine("Credit was set to " + VMachine.Credit);
            //MessageBox.Show("Credit was set to " + VMachine.Credit);
        }
        public ICommand ResetCommand { get; set; }
        private bool ResetCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void ResetCommand_Execute(object parameter)
        {
            VMachine.ResetCredit();
            CreditInfo = "Credit: " + VMachine.Credit;
        }
        #endregion

        #region Product Commands
        public ICommand FirstCommand { get; set; }
        private bool FirstCommand_CanExecute(object parameter)
        {          
           return true;
        }
        private void FirstCommand_Execute(object parameter)
        {
            VMachine.SellProduct("Cola");
            Credit = VMachine.Credit;
        }

        public ICommand SecondCommand { get; set; }
        private bool SecondCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void SecondCommand_Execute(object parameter)
        {
            VMachine.SellProduct("Water");
            Credit = VMachine.Credit;
        }

        public ICommand ThirdCommand { get; set; }
        private bool ThirdCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void ThirdCommand_Execute(object parameter)
        {
            VMachine.SellProduct("Sprite");
            Credit = VMachine.Credit;
        }

        public ICommand FourthCommand { get; set; }
        private bool FourthCommand_CanExecute(object parameter)
        {
            return true;
        }
        private void FourthCommand_Execute(object parameter)
        {
            VMachine.SellProduct("Fanta");
            Credit = VMachine.Credit;
        }       
        #endregion
    }
}
