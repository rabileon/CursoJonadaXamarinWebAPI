using JornadaXamarin.MobileApp.AppBase.Constants;
using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.AppBase.Storage;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Books;
using JornadaXamarin.MobileApp.Services.Interfaces;
using JornadaXamarin.MobileApp.Settings;
using JornadaXamarin.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.ViewModels
{
    public class MyBooksViewModel : BaseViewModel
    {
        private ObservableCollection<BookDTO> books;
        public ObservableCollection<BookDTO> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public Command RefreshCommand { get; set; }
        public Command AddCommand { get; set; }
        public MyBooksViewModel()
        {
            Title = "My Books";

            RefreshCommand = new(async () => await LoadBooks(true));
            AddCommand = new(async () => await App.Current.MainPage.Navigation.PushAsync(new NewBookPage()));
        }

        public async override Task OnAppearing()
            => await LoadBooks();


        public async Task LoadBooks(bool fromService = false)
        {
            if (!IsBusy)
            {
                IsBusy = true;

                IsRefreshing = true;
                var books = await SQLiteAsyncManager.Instance.GetAllAsync<BookDTO>();

                if (!books.Any())
                {
                    if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
                    {
                        IBooksService booksService = new BooksService(UserSettings.Token);
                        books = await booksService.GetBooks();
                        await SQLiteAsyncManager.Instance.InsertAllASync(books);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Loading Error", "Internet connection is needed", "Ok");
                    }

                }

                Books = new(books);

                IsRefreshing = false;
                IsBusy = false;
            }

        }

    }
}
