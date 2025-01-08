using System.ComponentModel.DataAnnotations;

namespace ConferenceManager
{
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public Event Event { get; set; }
    }
}
