using Homies.DataTransferObjects.Event;

namespace Homies.Services.Core.Contracts
{
    public interface IEventService
    {
        Task<EventFormModel> GetEventFormModelAsync();

        Task AddEventAsync(EventFormModel eventModel, string currentUserId);

        Task<IEnumerable<EventViewShortModel>> GetAllAsync();

        Task<bool> JoinAsync(int eventId, string currentUserId);

        Task<bool> LeaveAsync(int eventId, string currentUserId);

        Task<IEnumerable<EventViewShortModel>> GetJoinedEventsAsync(string currentUserId);

        Task<EventViewDetailsModel?> GetEventDetailsAsync(int id);

        Task<EventFormModel?> GetEventForEditAsync(int id, string currentUserId);

        Task<bool> EditEventAsync(int id, EventFormModel eventModel, string currentUserId);
    }
}
