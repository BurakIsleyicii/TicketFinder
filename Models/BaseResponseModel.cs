using Newtonsoft.Json;

namespace TicketFinder.Models;

public class BaseResponseModel<TData> where TData : class
{
    public string Status { get; set; }

    public TData Data { get; set; }

    public string Message { get; set; }

    [JsonProperty("user-message")]
    public string UserMessage { get; set; }

    [JsonProperty("api-request-id")]
    public string ApiRequestId { get; set; }

    public string Controller { get; set; }

    [JsonProperty("client-request-id")]
    public string ClientRequestId { get; set; }

    [JsonProperty("web-correlation-id")]
    public string WebCorrelationId { get; set; }

    [JsonProperty("correlation-id")]
    public string CorrelationId { get; set; }

    public object Parameters { get; set; }
}
