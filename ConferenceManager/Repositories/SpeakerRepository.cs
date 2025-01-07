using ConferenceManager.Services;

namespace ConferenceManager.Repositories
{
    public class SpeakerRepository
    {
        public static List<Speaker> speakers = new List<Speaker>();
        public List<Speaker> GetAllSpeakers(int EventId)
        {
            return speakers;
        }
    }
}
