using EventManagement.Contexts;
using EventManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using EventManagement.Models;

namespace EventManagement.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventManagementContext _context;

        public EventRepository(EventManagementContext context)
        {
            _context = context;
        }

        public Event Add(Event item)
        {
            _context.Events.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Event Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.Events.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public Event GetById(int key)
        {
            var bus = _context.Events.SingleOrDefault(x => x.EventId == key);
            return bus;
        }

        public List<Event> GetAll()
        {
            if (_context.Events.Count() == 0)
            {
                return null;
            }
            return _context.Events.ToList();
        }

        public Event Update(Event entity)
        {
            var eve = GetById(entity.EventId);
            if (eve != null)
            {
                _context.Entry<Event>(eve).State = EntityState.Modified;
                _context.SaveChanges();
                return eve;
            }
            return null;
        }

        public void SetSampleBus(Event sampleBus)
        {
            throw new NotImplementedException();
        }
    }
}
