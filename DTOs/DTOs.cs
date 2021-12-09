namespace DTOs;
public record NewBookDTO(string Title, string Author, string Editorial, string Image);
public record BookDTO(string Id, string Title, string Editorial, string Author, string Image);