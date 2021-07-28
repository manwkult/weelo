namespace Weelo.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyImage
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