namespace TicketFinder.Services.Interfaces;

public interface ISessionService
{
    T Get<T>(string key);
    void Set<T>(string key, T value);
    void Remove(string key);
}
