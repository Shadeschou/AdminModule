using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminModule.ViewModels
{

    /// <summary>
    /// The base for the viewmodel to be able to implement 
    /// The on PropertyChanged for each view. 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}