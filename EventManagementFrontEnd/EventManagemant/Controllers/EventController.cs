using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Exceptions;
using EventManagement.Interfaces;
using EventManagement.Models;
using EventManagement.Models.DTOs;
using EventManagement.Services;
using Microsoft.AspNetCore.Cors;
using EventManagement.Models.DTOs;
namespace EventManagement.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    [EnableCors("reactApp")] 
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService; 
        private readonly ILogger<EventController> _logger; 

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        //[Authorize(Roles = "Admin")]
        [Route("GetAllEvents")]
        [HttpGet]
        public ActionResult GetAllEvents()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.GetEvents();  
                return Ok(result); 
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Event eve)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.Add(eve); 
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Route("DeleteEvent")]
        [HttpPost]
        public ActionResult DeleteEvent(EventIdDTO eventIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.RemoveEvent(eventIdDTO); 
                return Ok(result); 
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Authorize(Roles = "Admin")]
        [Route("UpdateEvent")]
        [HttpPut]
        public ActionResult UpdateEvent(UpdateEventDTO eventDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.UpdateEvent(eventDTO); 
                return Ok(result);  
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);  
        }

        [HttpPost]
        [Route("GetEventById")]
        public ActionResult GetEventById(EventIdDTO eventIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.GetEventById(eventIdDTO);

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

    }

}