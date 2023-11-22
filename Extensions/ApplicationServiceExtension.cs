using TicketFinder.Services.Interfaces;
using TicketFinder.Services;

namespace TicketFinder.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ISessionService, SessionService>();
        services.AddSingleton<ITicketFinderService, TicketFinderService>();

        return services;
    }
}
