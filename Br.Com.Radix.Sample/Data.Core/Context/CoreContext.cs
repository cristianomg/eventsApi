using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Core.Context
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Event> Events { get; set; }
    }
}
