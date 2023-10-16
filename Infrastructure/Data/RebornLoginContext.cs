using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class RebornLoginContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
        .Property(p => p.Description)
        .IsRequired(false);
        }
        public RebornLoginContext(DbContextOptions<RebornLoginContext> options)
        : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
