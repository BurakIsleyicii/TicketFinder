using Newtonsoft.Json;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Services;

public class SessionService : ISessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public T Get<T>(string key)
    {
        string serializedData = _httpContextAccessor.HttpContext.Session.GetString(key);

        if (serializedData == null)
        {
            return default(T);
        }

        return JsonConvert.DeserializeObject<T>(serializedData);
    }

    public void Set<T>(string key, T value)
    {
        string existData = _httpContextAccessor.HttpContext.Session.GetString(key);

        if (existData != null)
            Remove(key);

        string serializedData = JsonConvert.SerializeObject(value);
        _httpContextAccessor.HttpContext.Session.SetString(key, serializedData);
    }

    public void Remove(string key)
    {
        _httpContextAccessor.HttpContext.Session.Remove(key);
    }
}
