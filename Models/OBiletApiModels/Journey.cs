using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class Journey
{
    public string Origin { get; set; }

    public string Destination { get; set; }

    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public string Currency { get; set; }

    public string Duration { get; set; }

    [JsonProperty("original-price")]
    public float OriginalPrice { get; set; }

    [JsonProperty("internet-price")]
    public float InternetPrice { get; set; }
}
