using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace JornadaXamarin.MobileApp.Settings
{
    public static class UserSettings
    {
        const string TOKEN_KEY = "token";

        public static string Token
        {
            get => Preferences.Get(TOKEN_KEY, string.Empty);
            set => Preferences.Set(TOKEN_KEY, value);
        }
    }
}
