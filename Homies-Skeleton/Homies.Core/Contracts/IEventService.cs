using Homies.DTO.Event;

namespace Homies.Services.Core.Contracts
{
    public interface IEventService
    {
        EventInputModel GetEventInputModel();

        void AddEvent(EventInputModel eventModel, string currentUserId);

        IEnumerable<EventShortViewModel> GetAll();
    }
}
