using Doctorly.Api.Dtos;
using Doctorly.Application.Interfaces;
using Doctorly.Application.Services;
using Doctorly.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctorly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IService _service;

        public AttendeeController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/accept-invite")]
        public async Task<IActionResult> AcceptInvitation([FromBody] AttendeeDto attendeeDto)
        {
            var attendee = new Attendee
            {
                Email = attendeeDto.Email,
                EventId = attendeeDto.EventId,
                FirstName = attendeeDto.FirstName,
                LastName = attendeeDto.LastName
            };
            await _service.AcceptEventInvitation(attendee);
            return Ok();
        }

        [HttpPost]
        [Route("/send-event-notification")]
        public async Task<IActionResult> SendEventNotification(int eventId)
        {
            await _service.SendEventNotification(eventId);
            return Ok();
        }
    }
}
