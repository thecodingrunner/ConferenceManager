using ConferenceManager.Repositories;

namespace ConferenceManager.Services
{
    public class EventsService
    {
        private readonly EventsRepository _eventsRepository;

        public EventsService(EventsRepository eventsModel)
        {
            _eventsRepository = eventsModel;
        }

        public List<Event> GetAllEvents()
        {
            return _eventsRepository.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventsRepository.GetEventById(id);
        }
    }
}
