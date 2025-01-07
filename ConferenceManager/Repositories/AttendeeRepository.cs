namespace ConferenceManager.Repositories
{
    public class AttendeeRepository
    {
        private static List<Attendee> attendees = new List<Attendee>();
        public int AddAttendee(Attendee attendee)
        {
            attendees.Add(attendee);
            return attendee.UserId;
        }

        public Attendee? GetAttendeeById(int attendeeId)
        {
            return attendees.Where(attendee => attendee.UserId == attendeeId).FirstOrDefault();
        }

        public List<Attendee> GetAttendees() {
        return attendees;
        }
    }
}
