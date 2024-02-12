﻿using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreProject.Models.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        
        public string UserName { get; set; }

        public string? Role { get; set; }
        public string? Token { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }

        public string? Email { get; set; }
        
    }
}

