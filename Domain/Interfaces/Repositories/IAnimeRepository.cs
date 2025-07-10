namespace Domain.Interfaces.Repositories;

using Domain.Entities;
using Domain.Interfaces.Services;

public interface IAnimeRepository
{
    Task<List<Anime>> GetAnimesAsync(AnimesFilter filter);
    Task<bool> CreateAnimeAsync(Anime anime);
    Task<bool> UpdateAnimeAsync(Anime anime);
    Task<bool> DeleteAnimeAsync(int Id);
}