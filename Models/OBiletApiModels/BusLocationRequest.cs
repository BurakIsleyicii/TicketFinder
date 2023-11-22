namespace TicketFinder.Models.OBiletApiModels;

public class BusLocationRequest
{
    public BusLocationRequest()
    {
        
    }

    public BusLocationRequest(string searchText)
    {
        SearchText = searchText;
    }

    public string SearchText { get; set; }
}

