using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JornadaXamarin.MobileApp.AppBase.Objects
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SetProperty<T>(ref T backing, T Value,
            [CallerMemberName] string propertyName = "")
        {

            backing = Value;
            OnPropertyChanged(propertyName);

        }
        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new(propertyName));
    }
}
