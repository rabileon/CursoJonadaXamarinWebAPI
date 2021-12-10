using Microsoft.EntityFrameworkCore;

namespace CursoJonadaXamarinWebAPI.Repositories;

public abstract class GenericRepository<T, TContext> : IDisposable, IGenericRepository<T>
    where T : class
    where TContext : DbContext
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _set;
    private readonly ILogger<GenericRepository<T, TContext>> _logger;

    public GenericRepository(DbContext dbContext, ILogger<GenericRepository<T, TContext>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        _set = _dbContext.Set<T>();
    }

    public async Task CreateAsync(T value)
    {
        await _set.AddAsync(value);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
     => await _set.ToListAsync();

    public async Task<T> GetByIdAsync(object id)
     => await _set.FindAsync(id)!;

    public async ValueTask DeleteByIdAsync(object id)
    {
        var value = await GetByIdAsync(id);
        if (value is not null)
            _set.Remove(value);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T Value)
    {
        _set.Update(Value);
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose() => _dbContext.Dispose();
}