using ConferenceManager.Repositories;

namespace ConferenceManager.Services
{
    public class SpeakerService
    {
        private readonly SpeakerRepository _speakerRepository;

        public SpeakerService(SpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public List<Speaker> GetAllSpeakers(int EventId)
        {
            return _speakerRepository.GetAllSpeakers(EventId);
        }
    }
}
