using Domain.Entities;
using Domain.Interfaces.Services;

namespace Domain.Interfaces.Services;

public interface IAnimeService
{
    Task<IEnumerable<Anime>> GetAnimes(AnimesFilter filter);
    Task<bool> CreateAnime(Anime anime);
    Task<bool> UpdateAnime(Anime anime);
    Task<bool> DeleteAnime(int Id);
}