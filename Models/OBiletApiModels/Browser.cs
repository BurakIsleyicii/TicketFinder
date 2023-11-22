namespace TicketFinder.Models.OBiletApiModels;

public class Browser
{
    public Browser()
    {
        
    }

    public Browser(string name, string version)
    {
        Name = name;
        Version = version;
    }

    public string Name { get; set; }

    public string Version { get; set; }
}
