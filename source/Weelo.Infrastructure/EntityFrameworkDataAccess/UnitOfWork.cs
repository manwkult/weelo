namespace Weelo.Infrastructure.EntityFrameworkDataAccess
{
    using System.Threading.Tasks;
    using System;
    using Weelo.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WeeloContext _context;

        public UnitOfWork(WeeloContext context)
        {
            this._context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}