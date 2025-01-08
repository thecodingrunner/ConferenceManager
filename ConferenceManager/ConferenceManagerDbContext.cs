using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace ConferenceManager
{
    public class ConferenceManagerDbContext : DbContext
    {
        public ConferenceManagerDbContext(DbContextOptions<ConferenceManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
