using Domain.Core.Entities;

namespace Api.Sample.Dtos
{
    public class DtoEvent
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string SensorName { get; set; }
        public string Value { get; set; }
        public long Timestamp { get; set; }
        public EventStatus Status { get; set; }
    }
}
