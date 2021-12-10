
using DTOs.Extensions;
using FluentValidation;

namespace CursoJonadaXamarinWebAPI.Routes;

public static class BooksRoutes
{
    private const string apiEndpoint = "api/books";
    private const string apiIdEndpoint = "api/books/{id}";

    internal static void AddBooksRoutes(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost(apiEndpoint, async (BooksRepository repository, IValidator<NewBookDTO> validator, NewBookDTO newBook) =>
        {
            var validationResult = validator.Validate(newBook);

            if (validationResult.IsValid)
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
            }
            else
            {
                return Results.ValidationProblem(validationResult.ToDictonary());
            }

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
            var item = await repository.GetByIdAsync(id);
            return Results.Ok(new BookDTO(item.Id, item.Title, item.Editorial, item.Author, item.Image));
        })
            .WithTags("Getters");

        routeBuilder.MapDelete(apiIdEndpoint, async (BooksRepository repository, string id) =>
        {
            await repository.DeleteByIdAsync(id);
            return Results.Ok();
        })
            .WithTags("Deletes");

        routeBuilder.MapPut(apiEndpoint, async (BooksRepository repository, string id, NewBookDTO bookDTO) =>
        {
            var book = await repository.GetByIdAsync(id);
            if (book is null)
            {
                return Results.NotFound();
            }

            book.Author = bookDTO.Author;
            book.Image = bookDTO.Image;
            book.Editorial = book.Editorial;
            book.Title = bookDTO.Title;

            await repository.UpdateAsync(book);

            return Results.Ok();
        });
    }
}