using System.Diagnostics;
using System.Windows;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Views
{
    /// <summary>
    /// Interaction logic for VendingWindow.xaml
    /// </summary>
    public partial class VendingWindow : Window
    {
        public VendingWindow()
        {
            this.DataContext = new VendingViewModel();
            InitializeComponent();

        }

        private void RepoButton_Click(object sender, RoutedEventArgs e)
        {

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://github.com/HerringTheCoder/VendingMachineSimulator",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
