namespace DTOs;
public record NewBookDTO(string Title, string Author, string Editorial, string Image);
public record BookDTO(string Id, string Title, string Editorial, string Author, string Image);

public record BranchDTO(string BranchId, string Name, string Location);

public record UserDTO(string Email, string Password, string Address, string UserName);
public record LoginDTO(string UserName, string Password);