using JornadaXamarin.MobileApp.AppBase.Helpers;
using JornadaXamarin.MobileApp.AppBase.Objects;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Books;
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
    public class NewBookViewModel : BaseViewModel
    {
        private string bookEditorial;
        public string BookEditorial
        {
            get => bookEditorial;
            set => SetProperty(ref bookEditorial, value);
        }
        private string bookAuthor;
        public string BookAuthor
        {
            get => bookAuthor;
            set => SetProperty(ref bookAuthor, value);
        }
        private string bookTitle;
        public string BookTitle
        {
            get => bookTitle;
            set => SetProperty(ref bookTitle, value);
        }
        private string photoPath;
        public string PhotoPath
        {
            get => photoPath;
            set => SetProperty(ref photoPath, value);
        }

        public Command TakePhotoCommand { get; set; }

        public Command PreviewBookCommand { get; set; }

        public Command SendBookCommand { get; set; }


        public NewBookViewModel()
        {
            Title = "New Book";
            TakePhotoCommand = new(async () => PhotoPath = await MediaHelper.TakePhotoAsync(bookId));
            PreviewBookCommand = new(async () => await PreviewBook());
            SendBookCommand = new(async () => await SendBook());
        }

        private async Task SendBook()
        {
            NewBookDTO newBook = new()
            {
                Author = BookAuthor,
                Editorial = BookEditorial,
                Title = BookTitle,
            };

            var azureImageUri = await AppBase.Helpers.BlobStorageHelper.UploadCover(bookId);

            newBook.Image = azureImageUri;

            IBooksService bookService = new BooksService(UserSettings.Token);
            var response = await bookService.PostBook(newBook);

            if (response)
            {
                await App.Current.MainPage.DisplayAlert("Book was created", $"{Title} was created successfully", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{BookTitle} was not created", "Ok");
            }
        }

        private async Task PreviewBook()
        {
            PreviewNewBookPage previewNewBookPage = new()
            {
                BindingContext = this
            };

            await App.Current.MainPage.Navigation.PushAsync(previewNewBookPage);
        }

        readonly string bookId = Guid.NewGuid().ToString();
    }
}
