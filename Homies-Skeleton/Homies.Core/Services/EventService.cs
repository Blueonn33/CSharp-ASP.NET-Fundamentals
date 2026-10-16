using Homies.Data;
using Homies.Data.Models;
using Homies.DTO.Event;
using Homies.Services.Core.Contracts;
using static Homies.GCommon.Constants.ApplicationConstants;

namespace Homies.Services.Core.Services
{
    public class EventService(
        HomiesDbContext dbContext,
        ITypeService typeService
        ) : IEventService
    {
        public EventInputModel GetEventInputModel()
        {
            EventInputModel model = new EventInputModel()
            {
                Types = typeService.GetTypes()
            };

            return model;
        }

        public void AddEvent(EventInputModel eventModel, string currentUserId)
        {
            var eventToAdd = new Event()
            {
                TypeId = eventModel.TypeId,
                Name = eventModel.Name,
                Description = eventModel.Description,
                CreatedOn = DateTime.Now,
                OrganizerId = currentUserId,
                Start = eventModel.Start,
                End = eventModel.End
            };

            dbContext.Events.Add(eventToAdd);
            dbContext.SaveChanges();
        }

        public IEnumerable<EventShortViewModel> GetAll()
        {
            return dbContext.Events
                .Select(e => new EventShortViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organizer = e.Organizer.UserName,
                    Start = e.Start.ToString(DateTimeFormat),
                    Type = e.Type.Name
                })
                .ToList();
        }
    }
}
