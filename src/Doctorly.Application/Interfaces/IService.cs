using Doctorly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.Application.Interfaces
{
    public interface IService
    {
        // I would have a seperate Inteface for Events and Attendees but because of time and there's no requirement to manipulate any atendee data
        Task CreateEvent(Event anEvent);
        Task UpdateEvent(Event anEvent);
        Task DeleteEvent(int eventId);
        Task<Event> GetEvent(int eventId);
        Task<IEnumerable<Event>> GetAllEvents();
        Task SendEventNotification(int eventId);

        
        Task AcceptEventInvitation(Attendee eventAttendee);
    }
}
