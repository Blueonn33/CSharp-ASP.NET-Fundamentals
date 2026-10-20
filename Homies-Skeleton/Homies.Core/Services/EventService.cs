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

        public bool Join(int eventId, string currentUserId)
        {
            var eventToAdd = dbContext.Events
                .Find(eventId);

            if (eventToAdd == null)
            {
                return false;
            }

            var entry = new EventParticipant()
            {
                EventId = eventToAdd.Id,
                HelperId = eventToAdd.OrganizerId
            };

            if (dbContext.EventsParticipants.Contains(entry) == false)
            {
                dbContext.EventsParticipants.Add(entry);
                dbContext.SaveChanges();
            }

            return true;
        }

        public bool Leave(int eventId, string currentUserId)
        {
            var eventToAdd = dbContext.Events
                .Find(eventId);

            if (eventToAdd == null)
            {
                return false;
            }

            var entry = dbContext.EventsParticipants
                .FirstOrDefault(e => e.HelperId == currentUserId && e.EventId == eventId);

            if (entry != null)
            {
                dbContext.EventsParticipants.Remove(entry);
                dbContext.SaveChanges();
            }

            return true;
        }

        public IEnumerable<EventShortViewModel> GetJoinedEvents(string currentUserId)
        {
            return dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == currentUserId)
                .Select(ep => new EventShortViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(DateTimeFormat),
                    Type = ep.Event.Type.Name
                })
                .ToList();
        }

        public EventDetailsViewModel? GetEventDetails(int id)
        {
            return dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    End = e.End.ToString(DateTimeFormat),
                    Organizer = e.Organizer.UserName,
                    Type = e.Type.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString(DateTimeFormat)
                })
                .FirstOrDefault();
        }

        public EventInputModel? GetEventForEdit(int id, string currentUserId)
        {
            var eventToEdit = dbContext.Events.Find(id);

            if (eventToEdit == null)
            {
                return null;
            }

            if (currentUserId != eventToEdit.OrganizerId)
            {
                throw new UnauthorizedAccessException();
            }

            EventInputModel eventModel = new EventInputModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                TypeId = eventToEdit.TypeId,
                Types = typeService.GetTypes()
            };

            return eventModel;
        }

        public bool EditEvent(int id, EventInputModel eventModel, string currentUserId)
        {
            var eventToEdit = dbContext.Events.Find(id);

            if (eventToEdit == null)
            {
                return false;
            }

            if (currentUserId != eventToEdit.OrganizerId)
            {
                throw new UnauthorizedAccessException();
            }

            if (typeService.GetTypes().Any(t => t.Id == eventModel.TypeId) == false)
            {
                throw new ArgumentException("Type does not exist");
            }

            eventToEdit.Name = eventModel.Name;
            eventToEdit.Description = eventModel.Description;
            eventToEdit.Start = eventModel.Start;
            eventToEdit.End = eventModel.End;
            eventToEdit.TypeId = eventModel.TypeId;

            dbContext.SaveChanges();
            return true;
        }
    }
}
