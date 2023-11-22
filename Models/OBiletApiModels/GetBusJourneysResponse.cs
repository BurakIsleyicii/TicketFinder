using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class GetBusJourneysResponse
{
    public int Id { get; set; }

    [JsonProperty("origin-location")]
    public string OriginLocation { get; set; }

    [JsonProperty("destination-location")]
    public string DestinationLocation { get; set; }

    [JsonProperty("origin-location-id")]
    public int OriginLocationid { get; set; }

    [JsonProperty("destination-location-id")]
    public int DestinationLocationId { get; set; }
    public Journey Journey { get; set; }

    [JsonProperty("is-active")]
    public bool IsActive { get; set; }
}
