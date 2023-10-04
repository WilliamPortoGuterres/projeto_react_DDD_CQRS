using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class RebornLoginContext : DbContext
    {
        public RebornLoginContext(DbContextOptions<RebornLoginContext> options)
        : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
