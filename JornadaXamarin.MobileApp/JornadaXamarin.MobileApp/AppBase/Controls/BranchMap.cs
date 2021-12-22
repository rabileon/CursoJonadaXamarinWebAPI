using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace JornadaXamarin.MobileApp.AppBase.Controls
{
    public class BranchMap : Map
    {
        public static readonly BindableProperty UserLocationProperty
            = BindableProperty.Create(nameof(UserLocation), typeof(Position), typeof(BranchMap), propertyChanged: OnUserPositionChanged);

        public Position UserLocation
        {
            get => (Position)GetValue(UserLocationProperty);
            set => SetValue(UserLocationProperty, value);
        }

        private static void OnUserPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Pin pin = new()
            {
                Label = "Me",
                Position = (Position)newValue
            };

            if (bindable is BranchMap branchMap)
            {
                branchMap.Pins.Add(pin);
                branchMap.MoveToRegion(MapSpan.FromCenterAndRadius((Position)newValue, Distance.FromKilometers(10)));
            }
        }

        public static readonly BindableProperty BranchLocationProperty
            = BindableProperty.Create(nameof(BranchLocation), typeof(Position), typeof(BranchMap), propertyChanged: OnBranchPositionChanged);

        public Position BranchLocation
        {
            get => (Position)GetValue(BranchLocationProperty);
            set => SetValue(BranchLocationProperty, value);
        }

        private static void OnBranchPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Pin pin = new()
            {
                Label = "Branch",
                Position = (Position)newValue
            };

            if (bindable is BranchMap branchMap)
            {
                branchMap.Pins.Add(pin);
                branchMap.MoveToRegion(MapSpan.FromCenterAndRadius((Position)newValue, Distance.FromKilometers(10)));
            }
        }
    }
}
