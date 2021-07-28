namespace Weelo.API.UseCases.v1.PropertyImage.AddPropertyImage
{
    using System.ComponentModel.DataAnnotations;
    
    public class AddPropertyImageRequest
    {
        public long Id { get; set; }

        [Required]
        public string File { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public long PropertyId { get; set; }
    }
}