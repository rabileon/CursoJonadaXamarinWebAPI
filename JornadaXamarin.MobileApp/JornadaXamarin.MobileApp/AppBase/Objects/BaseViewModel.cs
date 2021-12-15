using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.AppBase.Objects
{
    public class BaseViewModel : ObservableObject
    {
        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public async virtual Task OnAppearing()
        {

        }
    }
}
