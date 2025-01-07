using System.Text.Json;

namespace ConferenceManager.Repositories
{
    public class EventsRepository
    {
        public List<Event> Events { get; set; }
        public List<Event> GetAllEvents()
        {
            string fileContents = File.ReadAllText("events.json");
            Events = JsonSerializer.Deserialize<List<Event>>(fileContents);
            return Events;
        }

        public Event GetEventById(int id)
        {
            string fileContents = File.ReadAllText("events.json");
            Events = JsonSerializer.Deserialize<List<Event>>(fileContents);
            var e = Events.Where(e => e.Id == id).FirstOrDefault();
            return e;
        }
        public Event CreateEvent(Event e)
        {
            Events = GetAllEvents();
            Events.Add(e);
            //var eventsAsJson = JsonSerializer.Serialize(events);
            //File.WriteAllText("events.json", eventsAsJson);
            return e;
        }
    }
}
