using TicketFinder.Models.OBiletApiModels;

namespace TicketFinder.Services.Interfaces;

public interface IOBiletApiService
{
    Task<DeviceSession> GetSession();
    Task<List<BusLocationResponse>> GetBusLocations(string searchText);
    Task<List<GetBusJourneysResponse>> GetBusJourneys(GetBusJourneysRequest data);
}
