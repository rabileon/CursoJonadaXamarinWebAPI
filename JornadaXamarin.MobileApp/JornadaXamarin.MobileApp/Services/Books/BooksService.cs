using JornadaXamarin.MobileApp.AppBase.Constants;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Base;
using JornadaXamarin.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.Services.Books
{
    public class BooksService : BaseRestService, IBooksService
    {
        public BooksService(string token) : base(token)
        {

        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            Init();

            var books = await httpClient.GetFromJsonAsync<IEnumerable<BookDTO>>(MyAppBooksService.BOOKS);

            return books;
        }

        public async Task<bool> PostBook(NewBookDTO bookDTO)
        {
            Init();
            var response = await httpClient.PostAsJsonAsync(AppBase.Constants.MyAppBooksService.BOOKS, bookDTO);

            return response.IsSuccessStatusCode;
        }
    }
}
