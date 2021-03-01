using System;

namespace Domain.Core.Entities
{
    public class Event : Entity<Guid>
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string SensorName { get; set; }
        public string Value { get; set; }
        public long Timestamp { get; set; }
        public EventStatus Status { get; set; }
    }
}
