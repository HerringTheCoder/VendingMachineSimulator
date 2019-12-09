using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using VendingMachineApp.Models;


namespace VendingMachineApp.Views
{
    /// <summary>
    /// Interaction logic for VendingWindow.xaml
    /// </summary>
    public partial class VendingWindow : Window
    {
        public VendingWindow()
        {
            InitializeComponent();
        }

        private void RepoButton_Click(object sender, RoutedEventArgs e)
        {
            _ = new VendingMachine();
            /* ProcessStartInfo psi = new ProcessStartInfo
             {
                 FileName = "https://github.com/HerringTheCoder?tab=repositories",
                 UseShellExecute = true
             };
             Process.Start(psi);
             */
        }
    }
}
