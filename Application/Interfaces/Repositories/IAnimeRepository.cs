using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAnimeRepository
{
    Task<List<Anime>> GetAnimesAsync(Anime anime);
    Task<bool> CreateAnimesAsync(IEnumerable<Anime> anime);
    Task<bool> UpdateAnimeAsync(Anime anime);
    Task<bool> DeleteAnimeAsync(int Id);
}