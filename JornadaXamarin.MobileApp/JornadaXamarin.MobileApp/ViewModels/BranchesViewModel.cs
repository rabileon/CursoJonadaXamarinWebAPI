using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Branches;
using JornadaXamarin.MobileApp.Services.Interfaces;
using JornadaXamarin.MobileApp.Settings;
using JornadaXamarin.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class BranchesViewModel : BaseViewModel
    {
        public BranchesViewModel()
        {
            Title = "Branches";
        }

        public async override Task OnAppearing()
        {
            await LoadBranches();
        }

        async Task LoadBranches()
        {
            IBranchesService branchesServices = new BranchesService(UserSettings.Token);
            var branches = await branchesServices.GetBranches();
            Branches = new(branches);
            SelectionChangedCommand = new(async () => await NavigateToDetail());
        }

        private async Task NavigateToDetail()
        {
            if (SelectedBranch is not null)
            {
                BranchDetailPage branchDetailPage = new();
                if (branchDetailPage.BindingContext is BranchDetailViewModel detailViewModel)
                {
                    detailViewModel.Title = SelectedBranch.Name;
                    detailViewModel.Branch = SelectedBranch;
                }

                await App.Current.MainPage.Navigation.PushAsync(branchDetailPage);
                SelectedBranch = null;
            }



        }

        public Command SelectionChangedCommand { get; set; }

        private ObservableCollection<BranchDTO> branches;

        public ObservableCollection<BranchDTO> Branches
        {
            get => branches;
            set => SetProperty(ref branches, value);
        }

        private BranchDTO selectedBranch;

        public BranchDTO SelectedBranch
        {
            get => selectedBranch;
            set
            {

                SetProperty(ref selectedBranch, value);
                NavigateToDetail();
            }
        }

    }
}
