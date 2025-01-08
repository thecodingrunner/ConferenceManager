using Microsoft.Identity.Client;
using System.Text.Json.Serialization;

namespace ConferenceManager
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Venue { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public Speaker Speaker { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
