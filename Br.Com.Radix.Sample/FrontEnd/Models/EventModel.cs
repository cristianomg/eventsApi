using System.Text.Json.Serialization;

namespace FrontEnd.Models
{
    public class EventModel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("sensorName")]
        public string SensorName { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
