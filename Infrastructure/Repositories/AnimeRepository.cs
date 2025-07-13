using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Infrastructure.Contexts;
using Domain.Entities;

public class AnimeRepository(AnimesDbContext dbContext) : IAnimeRepository
{
    private readonly AnimesDbContext _dbContext = dbContext;

    public async Task<List<Anime>> GetAnimesAsync(Anime anime)
    {
        var query = _dbContext.Animes.AsQueryable();

        if (anime.Id > 0)
        {
            query = query.Where(a => a.Id == anime.Id);
        }

        if (!string.IsNullOrWhiteSpace(anime.Name))
        {
            query = query.Where(a => a.Name.Contains(anime.Name));
        }

        if (!string.IsNullOrWhiteSpace(anime.Director))
        {
            query = query.Where(a => a.Director.Contains(anime.Director));
        }

        return await query.ToListAsync();
    }
    public async Task<bool> CreateAnimesAsync(IEnumerable<Anime> animes)
    {
        foreach (var anime in animes)
        {
            _dbContext.Animes.Add(anime);
        }
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAnimeAsync(Anime anime)
    {
        _dbContext.Animes.Update(anime);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAnimeAsync(int Id)
    {
        var anime = await _dbContext.Animes.FindAsync(Id);
        if (anime == null) return false;
        _dbContext.Animes.Remove(anime);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}