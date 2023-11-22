using Newtonsoft.Json;

namespace TicketFinder.Models.OBiletApiModels
{
    public class Application
    {
        public Application()
        {
            Version = "1.0.0.0";
            EquipmentId = "distribusion";
        }

        public Application(string version, string equipmentId)
        {
            Version = version;
            EquipmentId = equipmentId;
        }

        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
