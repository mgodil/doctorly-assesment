using Doctorly.Application.Interfaces;
using Doctorly.Domain.Models;
using System.Collections;

namespace Doctorly.Application.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly EmailService _emailService;
        public Service(IRepository eventRepository, EmailService emailService)
        {
            _repository = eventRepository;
            _emailService = emailService;
        }

        public async Task CreateEvent(Event anEvent)
        {
            try
            {
              await _repository.CreateEvent(anEvent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            try
            {
                return await _repository.GetAllEvents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Event> GetEvent(int eventId)
        {
            try
            {
                return await _repository.GetEvent(eventId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public async Task DeleteEvent(int eventId)
        {
            try
            {
                await _repository.DeleteEvent(eventId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public async Task UpdateEvent(Event anEvent)
        {
            try
            {
                 await _repository.UpdateEvent(anEvent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task SendEventNotification(int eventId)
        {
            try
            {
                var attendees = await _repository.GetAllEventAttendes(eventId);

                foreach (var attendee in attendees)
                {
                    await _emailService.SendEmailAsync(attendee.Email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task AcceptEventInvitation(Attendee eventAttendee)
        {
            try
            {
                await _repository.AcceptEventInvitation(eventAttendee);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}