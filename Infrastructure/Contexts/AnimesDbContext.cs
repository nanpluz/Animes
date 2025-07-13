using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
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
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Director).HasMaxLength(200);
                entity.Property(e => e.Summary).HasMaxLength(2000);

                // Seed data
                entity.HasData(
                    new Anime { Id = 1, Name = "Naruto", Director = "Hayato Date", Summary = "A young ninja who seeks recognition and dreams of becoming the Hokage." },
                    new Anime { Id = 2, Name = "Fullmetal Alchemist", Director = "Seiji Mizushima", Summary = "Two brothers search for the Philosopher's Stone to restore their bodies." },
                    new Anime { Id = 3, Name = "Death Note", Director = "Tetsurō Araki", Summary = "A high school student discovers a notebook that kills anyone whose name is written in it." }
                );
            });
        }
    }
}
