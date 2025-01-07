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
        public Speaker CreateSpeaker(Speaker speaker) 
        {
            speakers.Add(speaker);
            return speaker;
        }
        public Speaker UpdateSpeaker(Speaker speaker) 
        {
            var currentSpeaker = speakers.Where(x => x.Id == speaker.Id).FirstOrDefault();
            currentSpeaker = speaker;
            return speaker;
        }
        public bool DeleteSpeaker(int id)
        {
            if (speakers.Any(x => x.Id == id))
            {
                speakers.Remove(speakers.Where(s => s.Id == id).First());
                return true;
            }
            return false;
        }
    }
}
