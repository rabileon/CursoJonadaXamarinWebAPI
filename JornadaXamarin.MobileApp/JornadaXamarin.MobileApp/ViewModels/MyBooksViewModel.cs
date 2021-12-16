using JornadaXamarin.MobileApp.AppBase.Constants;
using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Books;
using JornadaXamarin.MobileApp.Services.Interfaces;
using JornadaXamarin.MobileApp.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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

        public MyBooksViewModel()
        {
            Title = "My Books";
        }

        public async override Task OnAppearing()
        {
            IBooksService booksService = new BooksService(UserSettings.Token);
            Books = new(await booksService.GetBooks());
        }



    }
}
