namespace Weelo.API.UseCases.v1.Owner.CreateOwner
{
  using System;
  using System.ComponentModel.DataAnnotations;
    
    public class CreateOwnerRequest
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