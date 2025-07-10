using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure
{
    public class AnimesDbContext : DbContext
    {
        public AnimesDbContext(DbContextOptions<AnimesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.ToTable("Animes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Director).IsRequired();
            });
        }
    }
}
