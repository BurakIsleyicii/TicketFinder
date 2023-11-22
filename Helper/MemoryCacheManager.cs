using System.Runtime.Caching;

namespace TicketFinder.Helper;

public class MemoryCacheManager
{
    private static readonly object CacheLock = new object();
    private static MemoryCache _cache;

    private static MemoryCache Cache
    {
        get
        {
            if (_cache == null)
            {
                lock (CacheLock)
                {
                    if (_cache == null)
                    {
                        _cache = MemoryCache.Default;
                    }
                }
            }
            return _cache;
        }
    }

    public static void Add(string key, object value, TimeSpan expirationTime)
    {
        Remove(key);

        CacheItemPolicy policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.Add(expirationTime)
        };

        Cache.Add(key, value, policy);
    }

    public static T Get<T>(string key)
    {
        return (T)Cache.Get(key);
    }

    public static void Remove(string key)
    {
        if (Cache.Contains(key))
        {
            Cache.Remove(key);
        }
    }

    public static void Clear()
    {
        foreach (var item in Cache)
        {
            Cache.Remove(item.Key);
        }
    }
}
