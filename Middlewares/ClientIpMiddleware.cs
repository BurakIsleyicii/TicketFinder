using TicketFinder.Constants;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Middlewares
{
    public class ClientIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISessionService _sessionService;

        public ClientIpMiddleware(RequestDelegate next, ISessionService sessionService)
        {
            _next = next;
            _sessionService = sessionService;
        }

        public async Task Invoke(HttpContext context)
        {
            var data = _sessionService.Get<string>(SessionConstants.ClientIpKey);

            if (string.IsNullOrEmpty(data))
            {
                data = context.Connection.RemoteIpAddress?.ToString();
                _sessionService.Set(SessionConstants.ClientIpKey, data);
            }

            await _next(context);
        }
    }
}
