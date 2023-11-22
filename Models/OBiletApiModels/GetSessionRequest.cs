namespace TicketFinder.Models.OBiletApiModels;

public class GetSessionRequest
{
    public GetSessionRequest()
    {
        
    }
    public GetSessionRequest(string ip)
    {
        Type = 2;
        Connection = new Connection(ip);
        Application = new Application();
    }

    public int Type { get; set; }
    public Connection Connection { get; set; }
    public Application Application { get; set; }
}
