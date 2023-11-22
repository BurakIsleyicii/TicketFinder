using TicketFinder.Middlewares;

namespace TicketFinder.Extensions;

public static class ClientIpMiddlewareExtension
{
    public static IApplicationBuilder UseClientIpMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClientIpMiddleware>();
    }
}
