namespace CursoJonadaXamarinWebAPI.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task CreateAsync(T value);

    Task<T> GetById(object id);

    ValueTask DeleteById(object id);
}