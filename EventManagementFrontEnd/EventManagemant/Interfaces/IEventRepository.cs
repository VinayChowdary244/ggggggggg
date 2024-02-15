
using EventManagement.Models;
using EventManagement.Models;

namespace EventManagement.Interfaces
{
    public interface IEventRepository
    {
        public Event Add(Event  item);
        public Event Delete(int key);
        public Event GetById(int key);
        public List<Event> GetAll();
        public Event Update(Event item);
    }
}
