using Esgcore.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esgcore.DB
{
    public class EsgcoreDbContext : DbContext
    {
        public DbSet<Sector> Sectors { get; set; }

        public EsgcoreDbContext(DbContextOptions<EsgcoreDbContext> options)
            : base(options)
        {
        }
    }
}
