

using DTOs;

namespace CursoJonadaXamarinWebAPI.Routes;

public static class BooksRoutes
{
    private const string apiEndpoint = "api/books";
    private const string apiIdEndpoint = "api/books/{id}";

    internal static void AddBooksRoutes(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost(apiEndpoint, async (BooksRepository repository, NewBookDTO newBook) =>
        {
            Book book = new()
            {
                Author = newBook.Author,
                Image = newBook.Image,
                Title = newBook.Title,
                Id = Guid.NewGuid().ToString(),
                Editorial = newBook.Editorial
            };

            await repository.CreateAsync(book);

            return Results.Ok();
        })
            .WithTags("Creators");

        routeBuilder.MapGet(apiEndpoint, async (BooksRepository repository)
            => Results.Ok(
                (await repository.GetAllAsync())
                .Select(b => new BookDTO(b.Id, b.Title, b.Editorial, b.Author, b.Image))
                ))
            .WithTags("Getters");

        routeBuilder.MapGet(apiIdEndpoint, async (BooksRepository repository, string id)
            =>
        {
            var item = await repository.GetById(id);
            return Results.Ok(new BookDTO(item.Id, item.Title, item.Editorial, item.Author, item.Image));
        })
            .WithTags("Getters");

        routeBuilder.MapDelete(apiIdEndpoint, async (BooksRepository repository, string id) =>
        {
            await repository.DeleteById(id);
            return Results.Ok();
        })
            .WithTags("Deletes");
    }
}