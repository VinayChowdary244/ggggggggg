using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class User
    {
        
        public int UserId {get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
      
       
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }

    }
}
