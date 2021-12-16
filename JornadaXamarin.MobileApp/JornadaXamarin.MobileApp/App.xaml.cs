using JornadaXamarin.MobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JornadaXamarin.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
