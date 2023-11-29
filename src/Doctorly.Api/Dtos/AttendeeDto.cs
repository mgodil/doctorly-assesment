namespace Doctorly.Api.Dtos
{
    public class AttendeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int EventId { get; set; }
    }
}
