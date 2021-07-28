namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PropertyTrace")]
    public class PropertyTraceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tax { get; set; }

        [Required]
        public long PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public PropertyEntity Property { get; set; }
    }
}