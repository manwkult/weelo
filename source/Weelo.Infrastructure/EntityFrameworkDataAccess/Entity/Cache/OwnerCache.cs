namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache
{
    using System;

    public class OwnerCache
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}