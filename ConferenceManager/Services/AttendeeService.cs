using ConferenceManager.Repositories;

namespace ConferenceManager.Services
{
    public class AttendeeService
    {
        private readonly AttendeeRepository _attendeeRepository;

        public AttendeeService(AttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public int AddAttendee(Attendee attendee)
        {
            return _attendeeRepository.AddAttendee(attendee);
        }

        public Attendee? GetAttendeeById(int attendeeId)
        {
            return _attendeeRepository.GetAttendeeById(attendeeId);
        }
    }
}
