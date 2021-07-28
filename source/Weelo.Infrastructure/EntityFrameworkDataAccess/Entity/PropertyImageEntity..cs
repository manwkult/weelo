namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PropertyImage")]
    public class PropertyImageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string File { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public long PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public PropertyEntity Property { get; set; }
    }
}