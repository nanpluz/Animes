using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IAnimeService
{
    Task<IEnumerable<Anime>> GetAnimes(Anime filter);
    Task CreateAnime(Anime anime);
    Task UpdateAnime(Anime anime);
    Task DeleteAnime(int Id);
}