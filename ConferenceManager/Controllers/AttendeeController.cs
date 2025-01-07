using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace ConferenceManager.Controllers
{
    [Route("/attendees")]
    [ApiController]
    public class AttendeeController : Controller
    {

        private readonly EventsService _eventService;
        private readonly AttendeeService _attendeeService;
        private readonly UserService _userService;

        public AttendeeController(EventsService eventService, AttendeeService attendeeService, UserService userService)
        {
            _eventService = eventService;
            _attendeeService = attendeeService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost("/{EventId}")]
        public IActionResult AddAttendeeToEvent(int EventId, Attendee attendee)
        {
            var user = HttpContext.User;
            var sub = user.Claims.First(claim => claim.Type == "sub").Value;

            if (_userService.DoesUserExist(sub))
            {
                if (attendee != null && ModelState.IsValid)
                {
                    if (_eventService.GetEventById(EventId) != null)
                    {
                        return Ok(_attendeeService.AddAttendee(attendee));
                    }
                    return BadRequest("event does not exist");
                }
                return BadRequest("invalid attendee input");
            }
            return BadRequest("Unauthorised");
        }

        [Authorize]
        [HttpGet("/{attendeeId}")]
        public IActionResult GetAttendeeById(int attendeeId)
        {
            var user = HttpContext.User;
            var sub = user.Claims.First(claim => claim.Type == "sub").Value;
            if (sub.Equals(attendeeId))
            {
                return Ok(_attendeeService.GetAttendeeById(attendeeId));
            }
            return BadRequest("attendee does not exist");
        }
    }
}
