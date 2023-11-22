namespace TicketFinder.Models.ViewModels
{
    public class JourneyListVM
    {
        public JourneyListVM()
        {
            Journeys = new List<JourneyVM>();
        }

        public string Title { get; set; }
        public string DateText { get; set; }
        public List<JourneyVM> Journeys { get; set; }
    }
}
