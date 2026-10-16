using Homies.DTO.Event;

namespace Homies.Services.Core.Contracts
{
    public interface IEventService
    {
        EventInputModel GetEventInputModel();

        void AddEvent(EventInputModel eventModel, string currentUserId);

        IEnumerable<EventShortViewModel> GetAll();

        bool Join(int eventId, string currentUserId);

        bool Leave(int eventId, string currentUserId);

        IEnumerable<EventShortViewModel> GetJoinedEvents(string currentUserId);

        EventDetailsViewModel GetEventDetails(int id);
    }
}
