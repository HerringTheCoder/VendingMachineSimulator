using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VendingMachineApp.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine("Viewmodel " + propertyName + " has been updated.");
        }      
    }
}
