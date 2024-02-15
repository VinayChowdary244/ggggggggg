using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models.DTOs
{
    public class EventDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendies { get; set; }
        public int RegistrationFee { get; set; }
    }
}
