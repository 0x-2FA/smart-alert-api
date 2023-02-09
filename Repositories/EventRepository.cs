using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;

namespace smart_alert_api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SmartAlertContext _context;

        public EventRepository(SmartAlertContext context)
        {
            _context = context;
        }

        public void CreateEvent(Event evnt)
        {
            _context.Events.AddAsync(evnt);

            _context.SaveChangesAsync();
        }

        public void DeleteEventById(long id)
        {
            throw new NotImplementedException();
        }

        public Event? FindEventById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Event>? FindEventsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
