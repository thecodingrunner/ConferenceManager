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
        public List<Attendee> GetAttendees() 
        {
            return _attendeeRepository.GetAttendees();
        }

        public Attendee UpdateAttendee(Attendee attendee)
        {
            return _attendeeRepository.UpdateAttendee(attendee);
        }
        public bool DeleteAttendee(int id)
        {
            return _attendeeRepository.DeleteAttendee(id);
        }
    }
}
