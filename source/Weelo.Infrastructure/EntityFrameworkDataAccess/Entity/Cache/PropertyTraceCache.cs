namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache
{
    using System;
    using System.Text.Json.Serialization;

    public class PropertyTraceCache
    {
        public long Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public long PropertyId { get; set; }
    }
}