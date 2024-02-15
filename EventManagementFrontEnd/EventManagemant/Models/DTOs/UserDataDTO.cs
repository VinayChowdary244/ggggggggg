using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models.DTOs
{
    public class UserDataDTO
    {
       
        public string UserName { get; set; }

        public string? Email { get; set; }


        public byte[] Password { get; set; }

    }
}
