using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TicketFinder.Constants;
using TicketFinder.Helper;
using TicketFinder.Models;
using TicketFinder.Models.OBiletApiModels;
using TicketFinder.Models.ViewModels;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Services;

public class OBiletApiService : IOBiletApiService
{
    #region Ctor

    private readonly HttpClient _client;
    private readonly ISessionService _sessionService;

    public OBiletApiService(HttpClient client, ISessionService sessionService)
    {
        _client = client;
        _sessionService = sessionService;
    }

    #endregion

    public async Task<DeviceSession> GetSession()
    {
        var result = new DeviceSession();

        try
        {
            var ip = _sessionService.Get<string>(SessionConstants.ClientIpKey);
            if (string.IsNullOrEmpty(ip)) throw new ArgumentNullException(nameof(ip));

            var data = _sessionService.Get<DeviceSession>(SessionConstants.SessionKey(ip));
            if (data is not null && !string.IsNullOrEmpty(data.SessionId) && !string.IsNullOrEmpty(data.DeviceId))
                return data;

            var requestData = new GetSessionRequest(ip);
            var jsonContent = JsonConvert.SerializeObject(requestData);

            var response = await BasePostRequest<GetSessionResponse>("client/getsession", jsonContent);

            result = new DeviceSession(response.SessionId, response.DeviceId);
            _sessionService.Set(SessionConstants.SessionKey(ip), result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return result;
    }

    public async Task<List<BusLocationResponse>> GetBusLocations(string searchText)
    {
        var responseData = await PostRequest<List<BusLocationResponse>, string>("location/getbuslocations", searchText);
        return responseData.Where(x => x.CountryName.Equals("Türkiye", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<GetBusJourneysResponse>> GetBusJourneys(GetBusJourneysRequest data)
        => await PostRequest<List<GetBusJourneysResponse>, GetBusJourneysRequest>("journey/getbusjourneys", data);

    #region Private Methods

    private async Task<T> PostRequest<T, U>(string apiEndpoint, U requestData)
        where T : class
        where U : class
    {
        var sessionData = await GetSession();

        if (sessionData is null || string.IsNullOrEmpty(sessionData.SessionId) || string.IsNullOrEmpty(sessionData.DeviceId))
            throw new ValidationException("SessionId or DeviceId can not be null!");

        var requestModel = new BaseRequestModel<U>(requestData, sessionData, DateTime.UtcNow);

        var jsonContent = JsonConvert.SerializeObject(requestModel);

        return await BasePostRequest<T>(apiEndpoint, jsonContent);
    }

    private async Task<T> BasePostRequest<T>(string apiEndpoint, string requestJson)
        where T : class
    {
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(apiEndpoint, content);
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<BaseResponseModel<T>>(jsonResponse);

            if (responseModel is not null && responseModel.Status == "Success" && responseModel.Data is not null)
                return responseModel.Data;
        }

        return default;
    }

    #endregion
}
