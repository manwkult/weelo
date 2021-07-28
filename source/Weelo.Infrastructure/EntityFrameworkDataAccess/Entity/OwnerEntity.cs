namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    [Table("Owner")]
    public class OwnerEntity
    {
        public OwnerEntity()
        {
            Properties = new HashSet<PropertyEntity>();
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
        [Column(TypeName = "varchar(max)")]
        public string Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [JsonIgnore]
        public virtual ICollection<PropertyEntity> Properties { get; set; }
    }
}