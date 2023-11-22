namespace TicketFinder.Models.ViewModels
{
    public class DefaultFilterData
    {
        public DefaultFilterData()
        {
            OriginId = 349;
            Origin = "İstanbul Avrupa";
            DestinationId = 356;
            Destination = "Ankara";
            DepartureDate = DateTime.Now.AddDays(1).Date;
        }

        public DefaultFilterData(GetBusJourneyFormData data)
        {
            OriginId = data.OriginId;
            Origin = data.Origin;
            DestinationId = data.DestinationId;
            Destination = data.Destination;
            DepartureDate = data.DepartureDate;
        }

        public int OriginId { get; set; }
        public string Origin { get; set; }
        public int DestinationId { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
