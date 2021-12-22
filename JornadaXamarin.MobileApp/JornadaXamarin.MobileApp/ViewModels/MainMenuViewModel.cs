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
            MyBooks,
            Branches
        };
        public Command MyBooksCommand { get; set; }
        public Command BranchesCommand { get; set; }
        public MainMenuViewModel()
        {
            Title = "Main Menu";
            MyBooksCommand = new(async () => await NavigateTo(Pages.MyBooks));
            BranchesCommand = new(async () => await NavigateTo(Pages.Branches));
        }

        private async Task NavigateTo(Pages myBooks)
        {
            ContentPage target = myBooks switch
            {
                Pages.MyBooks => new MyBooksPage(),
                Pages.Branches => new BranchesPage(),
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
