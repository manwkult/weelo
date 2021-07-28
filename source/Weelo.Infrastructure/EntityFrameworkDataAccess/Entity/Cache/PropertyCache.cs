namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PropertyCache
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string InternalCode { get; set; }
        public short Year { get; set; }
        public long OwnerId { get; set; }
        public OwnerCache Owner { get; set; }
        public ICollection<PropertyImageCache> PropertyImages { get; set; }
        public ICollection<PropertyTraceCache> PropertyTraces { get; set; }
    }
}