namespace Weelo.API.UseCases.v1.Property.ChangePropertyPrice
{
    using System.ComponentModel.DataAnnotations;
    
    public class ChangePropertyPriceRequest
    {
        [Required]
        public long Id { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}