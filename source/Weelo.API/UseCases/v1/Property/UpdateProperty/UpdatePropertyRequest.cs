namespace Weelo.API.UseCases.v1.Property.UpdateProperty
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Weelo.Domain.Models;
    
    public class UpdatePropertyRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string InternalCode { get; set; }

        [Required]
        public short Year { get; set; }

        [Required]
        public long OwnerId { get; set; }

        public List<PropertyImage> PropertyImages { get; set; }
    }
}