namespace TicketFinder.Models.ViewModels
{
    public class JourneyVM
    {
        public JourneyVM() { }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Price { get; set; }
    }
}
