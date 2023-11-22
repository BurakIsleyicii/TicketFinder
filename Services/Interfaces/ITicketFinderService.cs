using TicketFinder.Models.ViewModels;

namespace TicketFinder.Services.Interfaces;

public interface ITicketFinderService
{
    DefaultFilterData GetDefaultFilterData();
    void SetDefaultFilterData(DefaultFilterData model);
    Task<List<BusLocationsVM>> GetBusLocations(string searchText = null);
    Task<JourneyListVM> GetBusJourneys(GetBusJourneyFormData data);
}
