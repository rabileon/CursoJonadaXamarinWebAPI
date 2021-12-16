using JornadaXamarin.MobileApp.AppBase.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JornadaXamarin.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : BindedPage
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
    }
}