namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    using Weelo.Domain.ValueObjects;

    [Table("Property")]
    public class PropertyEntity
    {
        public PropertyEntity()
        {
            PropertyImages = new HashSet<PropertyImageEntity>();
            PropertyTraces = new HashSet<PropertyTraceEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public ValidInternalCode InternalCode { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public short Year { get; set; }

        [Required]
        public long OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public OwnerEntity Owner { get; set; }

        [JsonIgnore]
        public virtual ICollection<PropertyImageEntity> PropertyImages { get; set; }
        [JsonIgnore]
        public virtual ICollection<PropertyTraceEntity> PropertyTraces { get; set; }
    }
}