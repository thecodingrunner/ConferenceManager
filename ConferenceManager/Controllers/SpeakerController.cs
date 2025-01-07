using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [Route("/speakers")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class SpeakerController : Controller
    {

        private readonly SpeakerService _speakerService;

        public SpeakerController(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("{EventId}")]
        [AllowAnonymous]
        public IActionResult GetAllSpeakers(int EventId)
        {
            return Ok(_speakerService.GetAllSpeakers(EventId));
        }

        [HttpPost]
        public IActionResult CreateSpeaker(Speaker speaker)
        {
           var result = _speakerService.AddSpeaker(speaker);
            if (result!=null) return Ok(result);
            return BadRequest("speaker not found");
        }
        [HttpPut]
        public IActionResult UpdateSpeaker(Speaker speaker) 
        { 
            var result = _speakerService.UpdateSpeaker(speaker);
            if (result != null) return Ok(result);
            return BadRequest("speaker not found");
        }
        [HttpDelete]
        public IActionResult DeleteSpeaker(int Id)
        {
            bool result = _speakerService.DeleteSpeaker(Id);
            if (result) return NoContent();
            return BadRequest("No matching speaker");
        }
    }
}
