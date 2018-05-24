using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmUtilities
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName]String caller = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}