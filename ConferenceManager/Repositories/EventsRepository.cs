using System.Text.Json;

namespace ConferenceManager.Repositories
{
    public class EventsRepository
    {
        public List<Event> GetAllEvents()
        {
            string fileContents = File.ReadAllText("events.json");
            var events = JsonSerializer.Deserialize<List<Event>>(fileContents);
            return events;
        }

        public Event GetEventById(int id)
        {
            string fileContents = File.ReadAllText("events.json");
            var events = JsonSerializer.Deserialize<List<Event>>(fileContents);
            var e = events.Where(e => e.Id == id).FirstOrDefault();
            return e;
        }
    }
}
