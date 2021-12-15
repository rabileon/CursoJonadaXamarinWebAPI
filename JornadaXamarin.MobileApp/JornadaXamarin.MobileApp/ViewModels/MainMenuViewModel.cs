using JornadaXamarin.MobileApp.AppBase.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {
            Title = "Main Menu";
        }

        public async override Task OnAppearing()
        {
            await App.Current.MainPage.DisplayAlert("Welcome", "Chose an option", "Ok");
        }
    }
}
