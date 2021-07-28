namespace Weelo.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Weelo.Domain.ValueObjects;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class WeeloContext : DbContext
    {
        public WeeloContext(DbContextOptions options) : base(options)
        { }

        DbSet<OwnerEntity> Owner { get; set; }
        DbSet<PropertyEntity> Property { get; set; }
        DbSet<PropertyImageEntity> PropertyImage { get; set; }
        DbSet<PropertyTraceEntity> PropertyTrace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyEntity>()
                .ToTable("Property")
                .Property(b => b.InternalCode)
                .HasConversion(
                  v => v.Value(),
                  v => new ValidInternalCode(v));

            modelBuilder.Entity<OwnerEntity>().HasData(
                new OwnerEntity {
                    Id = 1,
                    Name = "Jose Manuel Rios",
                    Address = "Carrera 123",
                    Photo = "//photo",
                    Birthday = DateTime.Now
                }
            );

        }
    }
}