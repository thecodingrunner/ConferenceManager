
namespace ConferenceManager.Services
{
    public interface IAttendeeService
    {
        int AddAttendee(Attendee attendee);
        bool DeleteAttendee(int id);
        Attendee? GetAttendeeById(int attendeeId);
        List<Attendee> GetAttendees();
        Attendee UpdateAttendee(Attendee attendee);
    }
}