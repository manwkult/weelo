namespace Weelo.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Owner
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}