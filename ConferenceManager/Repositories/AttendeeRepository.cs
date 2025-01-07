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

        public Attendee UpdateAttendee(Attendee attendee)
        {
            var currentAttendee = attendees.Where(x => x.UserId == attendee.UserId).FirstOrDefault();
            currentAttendee = attendee;
            return attendee;
        }
        public bool DeleteAttendee(int id)
        {
            if (attendees.Any(x => x.UserId == id))
            {
                attendees.Remove(attendees.Where(s => s.UserId == id).First());
                return true;
            }
            return false;
        }
    }
}
