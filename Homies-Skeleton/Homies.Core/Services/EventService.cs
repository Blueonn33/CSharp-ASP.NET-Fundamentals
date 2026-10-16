using Homies.DTO.Event;
using Homies.Services.Core.Contracts;

namespace Homies.Services.Core.Services
{
    public class EventService(ITypeService typeService) : IEventService
    {
        public EventInputModel GetEventInputModel()
        {
            EventInputModel model = new EventInputModel()
            {
                Types = typeService.GetTypes()
            };

            return model;
        }
    }
}
