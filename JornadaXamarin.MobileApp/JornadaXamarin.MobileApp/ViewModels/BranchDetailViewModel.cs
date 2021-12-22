using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class BranchDetailViewModel : BaseViewModel
    {
        public BranchDetailViewModel()
        {

        }

        private BranchDTO branch;

        public BranchDTO Branch
        {
            get => branch;
            set => SetProperty(ref branch, value);
        }
        private Position branchLocation;

        public Position BranchLocation
        {
            get => branchLocation;
            set => SetProperty(ref branchLocation, value);
        }

        private Position userLocation;

        public Position UserLocation
        {
            get => userLocation;
            set => SetProperty(ref userLocation, value);
        }

        public override async Task OnAppearing()
        {
            var placemarks = await Geocoding.GetLocationsAsync(branch.Location);
            var branchLocation = placemarks.First();

            BranchLocation = new(branchLocation.Latitude, branchLocation.Longitude);

            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(80));

            var location = await Geolocation.GetLocationAsync(request);

            UserLocation = new(location.Latitude, location.Longitude);
        }
    }
}
