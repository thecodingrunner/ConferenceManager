using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [Route("/speakers")]
    [ApiController]
    public class SpeakerController : Controller
    {

        private readonly SpeakerService _speakerService;

        public SpeakerController(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("/{EventId}")]
        public IActionResult GetAllSpeakers(int EventId)
        {
            return Ok(_speakerService.GetAllSpeakers(EventId));
        }
    }
}
