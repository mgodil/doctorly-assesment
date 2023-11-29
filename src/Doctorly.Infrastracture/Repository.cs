using Doctorly.Application.Interfaces;
using Doctorly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.Infrastracture
{
    public class Repository : IRepository
    {
        private readonly DoctorlyDbContext _doctorlyDbContext;

        public Repository(DoctorlyDbContext doctorlyDbContext)
        {
            _doctorlyDbContext = doctorlyDbContext;
        }
      

        public async Task CreateEvent(Event anEvent)
        {
            _doctorlyDbContext.Events.Add(anEvent);
            await _doctorlyDbContext.SaveChangesAsync();

        }

        public async Task UpdateEvent(Event anEvent)
        {
            var enEvent = await GetEvent(anEvent.Id);
            if (enEvent != null)
            {
                _doctorlyDbContext.Events.Update(anEvent);
                await _doctorlyDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEvent(int eventId)
        {
            var enEvent = await GetEvent(eventId);
            if (enEvent != null)
            {
                _doctorlyDbContext.Events.Remove(enEvent);
                await _doctorlyDbContext.SaveChangesAsync();
            }
        }

        public async Task<Event> GetEvent(int eventId)
        {
            return await _doctorlyDbContext.Events
                .Include(e => e.Attendees)
                .FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _doctorlyDbContext.Events.ToListAsync();
        }

        public async Task AcceptEventInvitation(Attendee eventAttendee)
        {
            _doctorlyDbContext.Attendees.Add(eventAttendee);
            await _doctorlyDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendee>> GetAllEventAttendes(int eventId)
        {
            return await _doctorlyDbContext.Attendees
                .Where(e=> e.EventId == eventId)
                .ToListAsync();
        }
    }
}