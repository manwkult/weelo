namespace Weelo.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PropertyTrace
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public decimal Tax { get; set; }
    }
}