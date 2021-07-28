namespace Weelo.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Weelo.Domain.ValueObjects;

    public class Property
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ValidInternalCode InternalCode { get; set; }

        [Required]
        public short Year { get; set; }

        [Required]
        public Owner Owner { get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
        public List<PropertyTrace> PropertyTraces { get; set; }
    }
}