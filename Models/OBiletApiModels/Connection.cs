using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels;

public class Connection
{
    public Connection()
    {
        
    }

    public Connection(string ipAddress)
    {
        IpAddress = ipAddress;
    }

    public Connection(string ipAddress, string port)
    {
        IpAddress = ipAddress;
        Port = port;
    }

    [JsonProperty("ip-address")]
    public string IpAddress { get; set; }

    public string Port { get; set; }
}
