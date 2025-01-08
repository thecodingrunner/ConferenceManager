using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace ConferenceManager.Controllers
{
    [Route("/attendees")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AttendeeController : ControllerBase
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

        [HttpPost("{EventId}")]
        public IActionResult AddAttendeeToEvent(int EventId, Attendee attendee)
        {
            var user = User;
            var role = user.FindFirstValue(ClaimTypes.Role);
            if (role != "Admin") return Unauthorized();
                if (attendee != null)
                {
                    if (_eventService.GetEventById(EventId) != null)
                    {
                        return Ok(_attendeeService.AddAttendee(attendee));
                    }
                
                return BadRequest("event does not exist");
                }
            return BadRequest("invalid attendee input");
        }

        [HttpGet("{attendeeId}")]
        [AllowAnonymous]
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllAttendees()
        {
            var user = HttpContext.User;
            if(user==null) return Unauthorized("User not logged in");
            var roles = user.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value);
            if (roles.Any(r => r == "Admin"))
            {
                return Ok(_attendeeService.GetAttendees());
            }
            return StatusCode(403,"Not in admin role");
        }

        [HttpPut]
        public IActionResult UpdateAttendee(Attendee attendee)
        {
            var result = _attendeeService.UpdateAttendee(attendee);
            if (result != null) return Ok(result);
            return BadRequest("attendee not found");
        }
        [HttpDelete]
        public IActionResult DeleteAttendee(int Id)
        {
            bool result = _attendeeService.DeleteAttendee(Id);
            if (result) return NoContent();
            return BadRequest("No matching attendee");
        }
    }
}
