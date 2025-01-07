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

        public Speaker AddSpeaker(Speaker speaker) {
        return _speakerRepository.CreateSpeaker(speaker);
        }
        public Speaker UpdateSpeaker(Speaker speaker)
        {
           return _speakerRepository.UpdateSpeaker(speaker);
        }
        public bool DeleteSpeaker(int id) 
        {
            return _speakerRepository.DeleteSpeaker(id);
        }

    }
}
