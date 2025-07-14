using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAnimeRepository
{
    Task<List<Anime>> GetAnimesAsync(Anime anime);
    Task CreateAnimeAsync(Anime anime);
    Task UpdateAnimeAsync(Anime anime);
    Task DeleteAnimeAsync(int Id);
}