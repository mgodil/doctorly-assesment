using Doctorly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.Application.Interfaces
{
    public interface IRepository
    {
        Task CreateEvent(Event anEvent);
        Task UpdateEvent(Event anEvent);
        Task DeleteEvent(int eventId);
        Task<Event> GetEvent(int eventId);
        Task<IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<Attendee>> GetAllEventAttendes(int eventId);
        Task AcceptEventInvitation(Attendee eventAttendee);
    }
}
