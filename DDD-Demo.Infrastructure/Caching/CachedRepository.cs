using Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ProjectName.Infrastructure.Caching;


public class CachedRepository<T> : IRepository<T> where T : class
{
    private readonly IRepository<T> _repository;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheLifetime;
    
    public CachedRepository(IRepository<T> repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
        _cacheLifetime = TimeSpan.FromMinutes(30);
    }
    
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cacheKey = $"{typeof(T).Name}_{id}";
        
        if (!_cache.TryGetValue(cacheKey, out T cachedItem))
        {
            cachedItem = await _repository.GetByIdAsync(id, cancellationToken);
            
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(_cacheLifetime);
            
            _cache.Set(cacheKey, cachedItem, cacheOptions);
        }
        
        return cachedItem;
    }
    
    // Implement other IRepository methods with caching...
}
