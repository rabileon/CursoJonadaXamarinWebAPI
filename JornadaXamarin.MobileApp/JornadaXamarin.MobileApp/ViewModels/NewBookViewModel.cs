using JornadaXamarin.MobileApp.AppBase.Helpers;
using JornadaXamarin.MobileApp.AppBase.Objects;
using System;
using System.Collections.Generic;
using System.Text;
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


        public NewBookViewModel()
        {
            Title = "New Book";
            TakePhotoCommand = new(async () => PhotoPath = await MediaHelper.TakePhotoAsync(bookId));
        }

        readonly string bookId = Guid.NewGuid().ToString();
    }
}
