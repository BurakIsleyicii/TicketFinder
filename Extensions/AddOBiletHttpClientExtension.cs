using TicketFinder.Services;
using TicketFinder.Services.Interfaces;
using TicketFinder.Settings;

namespace TicketFinder.Extensions;

public static class AddOBiletHttpClientExtension
{
    public static IServiceCollection AddOBiletHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var oBiletSettings = configuration.GetSection("OBiletSettings").Get<OBiletSettings>();

        services.AddHttpClient<IOBiletApiService, OBiletApiService>((serviceProvider, client) =>
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {oBiletSettings.Token}");
            client.BaseAddress = new Uri(oBiletSettings.BaseApiUrl);
        })
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler()
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(15)
            };
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        return services;
    }
}
