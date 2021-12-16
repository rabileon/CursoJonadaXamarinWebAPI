using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Authentication;
using JornadaXamarin.MobileApp.Services.Interfaces;
using JornadaXamarin.MobileApp.Settings;
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
            Name = "rabileonC";
            Password = "rabiLeon12345678.-";
#endif
            LoginCommand = new(async () => await LoginAsync());
        }


        private async Task LoginAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Error = string.Empty;

                LoginDTO loginDTO = new()
                {
                    Password = Password,
                    UserName = Name
                };
                IAuthenticationService authenticationService = new AuthenticationService();
                (bool success, string token) = await authenticationService.Login(loginDTO);

                if (success)
                {
                    UserSettings.Token = token.Replace("\"", "");
                    App.Current.MainPage = new NavigationPage(new MainMenuPage());
                }
                else
                {
                    Error = "No fue posible iniciar sesión";
                }

                IsBusy = false;
            }
        }

        private string error;

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
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
