using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IAnimeService
{
    Task<IEnumerable<Anime>> GetAnimes(Anime anime);
    Task<bool> CreateAnimes(IEnumerable<Anime> anime);
    Task<bool> UpdateAnime(Anime anime);
    Task<bool> DeleteAnime(int Id);
}