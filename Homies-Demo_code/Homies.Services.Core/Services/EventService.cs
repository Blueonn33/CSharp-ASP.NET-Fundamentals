using Homies.Data;
using Homies.Data.Models;
using Homies.DataTransferObjects.Event;
using Homies.Services.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services.Core.Services
{
    public class EventService : IEventService
    {
        private readonly ITypeService typeService;
        private readonly HomiesDbContext context;

        public EventService(
            ITypeService _typeService, 
            HomiesDbContext _context)
        {
            typeService = _typeService;
            context = _context;
        }

        public async Task AddEventAsync(EventFormModel eventModel, string currentUserId)
        {
            var eventToAdd = new Event()
            {
                Name = eventModel.Name,
                Description = eventModel.Description,
                CreatedOn = DateTime.Now,
                TypeId = eventModel.TypeId,
                OrganiserId = currentUserId,
                Start = eventModel.Start,
                End = eventModel.End
            };

            await context.Events.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<EventFormModel?> GetEventForEditAsync(int id, string currentUserId)
        {
            var eventToEdit = await context.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                return null;
            }

            if (currentUserId != eventToEdit.OrganiserId)
            {
                throw new UnauthorizedAccessException();
            }

            EventFormModel eventModel = new EventFormModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                TypeId = eventToEdit.TypeId,
                Types = await typeService.GetTypesAsync()
            };

            return eventModel;
        }

        public async Task<IEnumerable<EventViewShortModel>> GetAllAsync()
        {
            return await context
                .Events
                .Select(e => new EventViewShortModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<EventViewDetailsModel?> GetEventDetailsAsync(int id)
        {
            return await context
              .Events
              .Where(e => e.Id == id)
              .Select(e => new EventViewDetailsModel()
              {
                  Id = e.Id,
                  Name = e.Name,
                  Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                  End = e.End.ToString("dd/MM/yyyy H:mm"),
                  Organiser = e.Organiser.UserName,
                  Type = e.Type.Name,
                  Description = e.Description,
                  CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm")
              })
              .FirstOrDefaultAsync();
        }

        public async Task<EventFormModel> GetEventFormModelAsync()
        {
            EventFormModel eventModel = new EventFormModel()
            {
                Types = await typeService.GetTypesAsync()
            };

            return eventModel;
        }

        public async Task<IEnumerable<EventViewShortModel>> GetJoinedEventsAsync(string currentUserId)
        {
            return await context
                .EventsParticipants
                .Where(ep => ep.HelperId == currentUserId)
                .Select(ep => new EventViewShortModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString("dd/MM/yyyy H:mm"),
                    Type = ep.Event.Type.Name
                })
                .ToListAsync();
        }

        public async Task<bool> JoinAsync(int eventId, string currentUserId)
        {
            var eventToAdd = await context
                .Events
                .FindAsync(eventId);

            if (eventToAdd == null)
            {
                return false;
            }

            var entry = new EventParticipant()
            {
                EventId = eventToAdd.Id,
                HelperId = currentUserId,
            };

            if (await context.EventsParticipants.ContainsAsync(entry) == false)
            {
                await context.EventsParticipants.AddAsync(entry);
                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> LeaveAsync(int eventId, string currentUserId)
        {
            var eventToLeave = await context.Events.FindAsync(eventId);

            if (eventToLeave == null)
            {
                return false;
            }

            var entry = await context.EventsParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == currentUserId && ep.EventId == eventId);
            
            if (entry != null) 
            {
                context.EventsParticipants.Remove(entry);
                await context.SaveChangesAsync();
            }
            
            return true;
        }

        public async Task<bool> EditEventAsync(int id, EventFormModel eventModel, string currentUserId)
        {
            var eventToEdit = await context.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                return false;
            }

            if (currentUserId != eventToEdit.OrganiserId)
            {
                throw new UnauthorizedAccessException();
            }

            if ((await typeService.GetTypesAsync()).Any(e => e.Id == eventModel.TypeId) == false)
            {
                throw new ArgumentException("Type does not exist!");
            }

            eventToEdit.Name = eventModel.Name;
            eventToEdit.Description = eventModel.Description;
            eventToEdit.Start = eventModel.Start;
            eventToEdit.End = eventModel.End;
            eventToEdit.TypeId = eventModel.TypeId;

            await context.SaveChangesAsync();
            
            return true;
        }
    }
}
