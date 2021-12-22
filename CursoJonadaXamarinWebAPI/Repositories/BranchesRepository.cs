namespace CursoJonadaXamarinWebAPI.Repositories;

public class BranchesRepository : GenericRepository<Branch, BooksContext.CursoJornadaXamarin2021Context>
{
    public BranchesRepository(BooksContext.CursoJornadaXamarin2021Context booksContext, ILogger<BranchesRepository> logger) : base(booksContext, logger)
    {

    }
}

