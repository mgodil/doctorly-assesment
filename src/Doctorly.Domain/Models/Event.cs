using System.Text.Json.Serialization;

namespace Doctorly.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Attendee>? Attendees { get; set; }
    }
}
