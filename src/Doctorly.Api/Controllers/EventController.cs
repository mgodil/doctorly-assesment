using Doctorly.Api.Dtos;
using Doctorly.Application.Interfaces;
using Doctorly.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doctorly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IService _service;

        public EventController(IService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _service.GetAllEvents();
        }


        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            return await _service.GetEvent(id);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] EventDto eventDto)
        {
            var anEvent = new Event()
            {
                Description = eventDto.Description,
                EndTime = eventDto.EndTime,
                StartTime = eventDto.StartTime,
            };
            await _service.CreateEvent(anEvent);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EventDto eventDto)
        {
            var anEvent = new Event()
            {   Id = id,
                Description = eventDto.Description,
                EndTime = eventDto.EndTime,
                StartTime = eventDto.StartTime,
            };
            await _service.UpdateEvent(anEvent);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteEvent(id);
        }
    }
}
