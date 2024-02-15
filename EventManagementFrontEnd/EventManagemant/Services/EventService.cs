using EventManagement.Exceptions;
using EventManagement.Models.DTOs;
using EventManagement.Interfaces;
using EventManagement.Models;
using EventManagement.Models.DTOs;

namespace EventManagement.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

       
        public EventService(IEventRepository repository)
        {
            _eventRepository = repository;
        }
        public Event Add(Event eve)
        {
            var result = _eventRepository.Add(eve);
            return result;
        }

        public Event GetEventById(EventIdDTO eventIdDTO)
        {
            var result = _eventRepository.GetById(eventIdDTO.EventId);
            return result;
        }

        public List<Event> GetEvents()
        {
            var events = _eventRepository.GetAll();
            if (events != null)
            {
                return events.ToList();
            }
            throw new NoEventsAvailableException();
        }

        public EventIdDTO RemoveEvent(EventIdDTO eventIdDTO)
        {
            var EventToBeRemoved = _eventRepository.GetById(eventIdDTO.EventId);
            if (EventToBeRemoved != null)
            {
                var result = _eventRepository.Delete(eventIdDTO.EventId);
                if (result != null)
                {
                    return eventIdDTO;
                }
            }
            return null;
        }

        public UpdateEventDTO UpdateEvent(UpdateEventDTO eventDTO)
        {
            var eventData = _eventRepository.GetById(eventDTO.EventId);
            eventData.Title = eventDTO.Title;
            eventData.Description = eventDTO.Description;
            eventData.Date = eventDTO.Date;
            eventData.Location = eventDTO.Location;
            eventData.MaxAttendies = eventDTO.MaxAttendies;
            eventData.RegistrationFee = eventDTO.RegistrationFee;



          


            if (eventData != null)
            {
                var result = _eventRepository.Update(eventData);
                if (result != null)
                {
                    return eventDTO;
                }
            }
            return null;
        }
    }
}
