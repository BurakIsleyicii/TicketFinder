using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class GetBusJourneysRequest
{
    public GetBusJourneysRequest()
    {
        
    }
    public GetBusJourneysRequest(int originId, int destinationId, string departureDate)
    {
        OriginId = originId;
        DestinationId = destinationId;
        DepartureDate = departureDate;
    }

    [JsonProperty("origin-id")]
    public int OriginId { get; set; }

    [JsonProperty("destination-id")]
    public int DestinationId { get; set; }

    [JsonProperty("departure-date")]
    public string DepartureDate { get; set; }
}
