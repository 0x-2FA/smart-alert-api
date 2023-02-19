﻿using smart_alert_api.Models.Database;

namespace smart_alert_api.Services.Events
{
    public record ImportantEventsResult(Event? earthquakeEvents, Event? importantFireEvent, Event? importantFloodEvent);
}
