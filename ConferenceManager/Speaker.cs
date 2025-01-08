namespace ConferenceManager
{
    public class Speaker
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
