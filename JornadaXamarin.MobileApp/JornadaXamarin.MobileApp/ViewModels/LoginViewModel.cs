using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Login";

#if DEBUG
            Name = "RabiAdmin";
            Password = "Rabi123456";
#endif
            LoginCommand = new(async () => await LoginAsync());
        }


        private async Task LoginAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Task.Delay(2000);
                App.Current.MainPage = new NavigationPage(new MainMenuPage());

                IsBusy = false;
                IsBusy = false;
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public Command LoginCommand { get; set; }

    }
}
