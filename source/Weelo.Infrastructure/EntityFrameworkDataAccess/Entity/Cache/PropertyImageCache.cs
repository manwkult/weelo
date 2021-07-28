namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache
{

    public class PropertyImageCache
    {
        public long Id { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public long PropertyId { get; set; }
    }
}