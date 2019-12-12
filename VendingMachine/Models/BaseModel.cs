using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace VendingMachineApp.Models
{
    class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine("Model " + propertyName + " has been updated.");
        }
        #endregion
    }
}
