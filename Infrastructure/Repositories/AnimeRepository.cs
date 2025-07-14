using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Infrastructure.Contexts;
using Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class AnimeRepository(AnimesDbContext dbContext) : IAnimeRepository
{
    private readonly AnimesDbContext _dbContext = dbContext;

    public async Task<List<Anime>> GetAnimesAsync(Anime filter)
    {
        var query = _dbContext.Animes.AsQueryable();

        if (filter.Id > 0)
        {
            query = query.Where(a => a.Id == filter.Id);
        }

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(a => a.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrWhiteSpace(filter.Director))
        {
            query = query.Where(a => a.Director.Contains(filter.Director));
        }

        return await query.ToListAsync();
    }
    public async Task CreateAnimeAsync(Anime anime)
    {
        _dbContext.Animes.Add(anime);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateAnimeAsync(Anime anime)
    {
        var existingAnime = await _dbContext.Animes.FindAsync(anime.Id);
        if (existingAnime == null) throw new KeyNotFoundException("Anime not found");

        if (!string.IsNullOrWhiteSpace(anime.Name))
            existingAnime.Name = anime.Name;

        if (!string.IsNullOrWhiteSpace(anime.Director))
            existingAnime.Director = anime.Director;

        if (!string.IsNullOrWhiteSpace(anime.Summary))
            existingAnime.Summary = anime.Summary;

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAnimeAsync(int Id)
    {
        var anime = await _dbContext.Animes.FindAsync(Id);
        if (anime == null) throw new KeyNotFoundException("Anime not found");
        _dbContext.Animes.Remove(anime);
        await _dbContext.SaveChangesAsync();
    }
}