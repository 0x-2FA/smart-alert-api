using System;
using System.Collections.Generic;

namespace smart_alert_api.Models.Database
{
    public partial class Event
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? Timestamp { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Photo { get; set; }
        public string? Comment { get; set; }
        public string? UserId { get; set; }

        public virtual EntityUser? User { get; set; }
    }
}
