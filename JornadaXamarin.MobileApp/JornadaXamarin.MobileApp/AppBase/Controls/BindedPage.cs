using JornadaXamarin.MobileApp.AppBase.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace JornadaXamarin.MobileApp.AppBase.Controls
{
    public class BindedPage : ContentPage
    {
        public BindedPage()
            => On<iOS>().SetUseSafeArea(true);

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is BaseViewModel baseViewModel)
            {
                await baseViewModel.OnAppearing();
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            Binding titleBinding = new("Title");
            SetBinding(TitleProperty, titleBinding);
        }
    }
}
