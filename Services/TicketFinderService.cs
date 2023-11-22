using TicketFinder.Constants;
using TicketFinder.Helper;
using TicketFinder.Models.OBiletApiModels;
using TicketFinder.Models.ViewModels;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Services;

public class TicketFinderService : ITicketFinderService
{
    #region Ctor
    private readonly IOBiletApiService _oBiletApiService;
    private readonly ISessionService _sessionService;

    public TicketFinderService(IOBiletApiService oBiletApiService, ISessionService sessionService)
    {
        _oBiletApiService = oBiletApiService;
        _sessionService = sessionService;
    }
    #endregion

    public DefaultFilterData GetDefaultFilterData()
    {
        DefaultFilterData result = new DefaultFilterData();

        var data = _sessionService.Get<DefaultFilterData>(SessionConstants.DefaultFilterKey);
        if (data is not null && data.OriginId > 0 && data.DestinationId > 0)
            result = data;

        return result;
    }

    public void SetDefaultFilterData(DefaultFilterData model) =>
        _sessionService.Set(SessionConstants.DefaultFilterKey, model);

    public async Task<List<BusLocationsVM>> GetBusLocations(string searchText = null)
    {
        var result = new List<BusLocationsVM>();
        var apiResponse = new List<BusLocationResponse>();

        try
        {
            var cachedData = MemoryCacheManager.Get<List<BusLocationResponse>>(CacheConstants.BusLocationsKey(searchText));

            if (cachedData is null)
            {
                apiResponse = await _oBiletApiService.GetBusLocations(searchText);
                MemoryCacheManager.Add(CacheConstants.BusLocationsKey(searchText), apiResponse, TimeSpan.FromMinutes(10));
            }
            else apiResponse = cachedData;

            result = apiResponse.Select(x => new BusLocationsVM { Id = x.Id, Name = x.Name }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return result;
    }

    public async Task<JourneyListVM> GetBusJourneys(GetBusJourneyFormData data)
    {
        JourneyListVM result = new JourneyListVM();

        try
        {
            SetDefaultFilterData(new DefaultFilterData(data));

            var response = await _oBiletApiService.GetBusJourneys(new GetBusJourneysRequest(data.OriginId, data.DestinationId, data.DepartureDate.ToString("yyyy-MM-dd")));

            result.Title = $"{data.Origin} - {data.Destination}";
            result.DateText = data.DepartureDate.ToString("dd MMMM dddd");
            result.Journeys = response.OrderBy(x => x.Journey.Departure).Select(x => new JourneyVM
            {
                Price = $"{x.Journey.InternetPrice.ToString("0.00")} {x.Journey.Currency}",
                ArrivalTime = x.Journey.Arrival.ToShortTimeString(),
                DepartureTime = x.Journey.Departure.ToShortTimeString(),
                Origin = x.Journey.Origin,
                Destination = x.Journey.Destination
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return result;
    }
}
