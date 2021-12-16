using JornadaXamarin.MobileApp.AppBase.Controls;
using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        enum Pages
        {
            MyBooks
        };
        public Command MyBooksCommand { get; set; }
        public MainMenuViewModel()
        {
            Title = "Main Menu";
            MyBooksCommand = new(async () => await NavigateTo(Pages.MyBooks));
        }

        private async Task NavigateTo(Pages myBooks)
        {
            BindedPage target = myBooks switch
            {
                Pages.MyBooks => new MyBooksPage(),
                _ => throw new Exception("Target is not valid")
            };
            await App.Current.MainPage.Navigation.PushAsync(target);
        }

        public async override Task OnAppearing()
        {
            await App.Current.MainPage.DisplayAlert("Welcome", "Chose an option", "Ok");
        }
    }
}
