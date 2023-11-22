using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class BusLocationResponse
{
    public int Id { get; set; }

    [JsonProperty("parent-id")]
    public int Parentid { get; set; }

    public string Name { get; set; }

    [JsonProperty("country-name")]
    public string CountryName { get; set; }

    public object Code { get; set; }

    [JsonProperty("long-name")]
    public string LongName { get; set; }
}
