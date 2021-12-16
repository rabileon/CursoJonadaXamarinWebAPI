using JornadaXamarin.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.Services.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDTO>> GetBooks();
    }
}
