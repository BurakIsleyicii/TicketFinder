namespace TicketFinder.Constants
{
    public class CacheConstants
    {
        public static string BusLocationsKey(string searchText = null) => string.IsNullOrEmpty(searchText) ? "AllBusLocations" : $"BusLocations_{searchText}";
    }
}
