namespace CursoJonadaXamarinWebAPI.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task CreateAsync(T value);

    Task<T> GetByIdAsync(object id);

    ValueTask DeleteByIdAsync(object id);
    Task UpdateAsync(T value);
}