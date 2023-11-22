using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class DeviceSession
{
    public DeviceSession()
    {

    }

    public DeviceSession(string sessionId, string deviceId)
    {
        SessionId = sessionId;
        DeviceId = deviceId;
    }

    [JsonProperty("session-id")]
    public string SessionId { get; set; }

    [JsonProperty("device-id")]
    public string DeviceId { get; set; }
}
