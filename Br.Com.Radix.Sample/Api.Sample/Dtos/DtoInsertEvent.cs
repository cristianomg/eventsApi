using System;
using System.Text.Json.Serialization;

namespace Api.Sample.Dtos
{
    public class DtoInsertEvent
    {
        /// <summary>
        /// Unix Timestamp ex: 1539112021301
        /// </summary>
        [JsonPropertyName("timestamp")]
        public TimeSpan Timestamp { get; set; }
        /// <summary>
        /// string separada por '.' ex: brasil.sudeste.sensor01 
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// dado coletado de um determinado sensor (podendo ser numérico ou string).
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }

    }
}
