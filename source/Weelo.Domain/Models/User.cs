namespace Weelo.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Required]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}