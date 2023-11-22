using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels
{
    public class GetSessionResponse
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        public object Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }

        public object Device { get; set; }

        [JsonProperty("ip-country")]
        public string IpCountry { get; set; }
    }
}
