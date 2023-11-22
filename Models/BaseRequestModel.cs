using Newtonsoft.Json;
using TicketFinder.Models.OBiletApiModels;

namespace TicketFinder.Models;

public class BaseRequestModel<TData> where TData : class
{
    public BaseRequestModel()
    {
        
    }

    public BaseRequestModel(TData data, DeviceSession deviceSession, DateTime date, string language = "tr-TR")
    {
        Data = data;
        DeviceSession = deviceSession;
        Date = date;
        Language = language;
    }

    public TData Data { get; set; }

    [JsonProperty("device-session")]
    public DeviceSession DeviceSession { get; set; }

    public DateTime Date { get; set; }

    public string Language { get; set; }
}
