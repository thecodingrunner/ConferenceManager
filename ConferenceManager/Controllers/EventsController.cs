using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [Route("/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsService _eventsService;

        public EventsController(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            List<Event> events = _eventsService.GetAllEvents();
            if (events != null)
            {
                return Ok(events);
            }
            return BadRequest();
        }

        [HttpGet("/{id}")]
        public IActionResult GetEventById(int id)
        {
            Event e = _eventsService.GetEventById(id);
            if (e != null)
            {
                return Ok(e);
            }
            return NotFound();
        }
    }
}
