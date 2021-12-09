using CursoJonadaXamarinWebAPI.BooksContext;

namespace CursoJonadaXamarinWebAPI.Repositories;

public class BooksRepository : GenericRepository<Book, BooksContext.CursoJornadaXamarin2021Context>
{
    public BooksRepository(BooksContext.CursoJornadaXamarin2021Context booksContext, ILogger<BooksRepository> logger)
    : base(booksContext, logger)
    {
    }


}

