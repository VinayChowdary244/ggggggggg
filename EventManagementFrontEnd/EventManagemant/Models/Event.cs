using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendies { get; set; }
        public int RegistrationFee { get; set; }


    }
}
