using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }
    public async Task<IEnumerable<Anime>> GetAnimes(AnimesFilter filter)
    {
        return await _animeRepository.GetAnimesAsync(filter);
    }
    public async Task<bool> CreateAnime(Anime anime)
    {
        return await _animeRepository.CreateAnimeAsync(anime);
    }
    public async Task<bool> UpdateAnime(Anime anime)
    {
        return await _animeRepository.UpdateAnimeAsync(anime);
    }
    public async Task<bool> DeleteAnime(int Id)
    {
        return await _animeRepository.DeleteAnimeAsync(Id);
    }
}
