using EventManagement.Models.DTOs;
using EventManagement.Models;
using EventManagement.Models.DTOs;

namespace EventManagement.Interfaces
{
    public interface IEventService
    {
        List<Event> GetEvents();
        Event Add(Event eve);
        EventIdDTO RemoveEvent(EventIdDTO eventIdDTO);
        UpdateEventDTO UpdateEvent(UpdateEventDTO eventDTO);
        Event GetEventById(EventIdDTO eventIdDTO);
    }
}
