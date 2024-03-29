﻿using smart_alert_api.Models.Database;

namespace smart_alert_api.Interfaces
{
    public interface IEventRepository
    {
        Event? FindEventById(long id);
        List<Event>? FindEventsByUserId(string userId);
        List<Event>? GetAllEvents();
        List<Event> GetEventsByType(string type);
        void CreateEvent(Event evnt);
        void DeleteEventById(long id);
    }
}
