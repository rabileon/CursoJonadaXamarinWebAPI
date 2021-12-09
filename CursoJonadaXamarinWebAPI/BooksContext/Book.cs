using System;
using System.Collections.Generic;

namespace CursoJonadaXamarinWebAPI.BooksContext
{
    public partial class Book
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
