using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Settings;
using JornadaXamarin.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        public SplashScreenViewModel()
        {

        }

        public async override Task OnAppearing()
        {
            var token = UserSettings.Token;

            if (string.IsNullOrWhiteSpace(token))
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new MainMenuPage());
            }
        }
    }
}
