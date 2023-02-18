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
            var evnt = FindEventById(id);

            _context.Remove(evnt);

            _context.SaveChangesAsync();
        }

        public Event? FindEventById(long id)
        {
            return _context.Events.FirstOrDefault( evnt => evnt.Id == id );
        }

        public List<Event>? FindEventsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Event>? GetAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
