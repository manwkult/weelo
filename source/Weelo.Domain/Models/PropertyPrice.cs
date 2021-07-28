namespace Weelo.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyPrice
    {
        [Required]
        public long Id { get; set; }        

        [Required]
        public decimal Price { get; set; }
    }
}