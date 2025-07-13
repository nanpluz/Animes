using Domain.Entities;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;

namespace Infrastructure.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }
    public async Task<IEnumerable<Anime>> GetAnimes(Anime anime)
    {
        return await _animeRepository.GetAnimesAsync(anime);
    }
    public async Task<bool> CreateAnimes(IEnumerable<Anime> animes)
    {
        return await _animeRepository.CreateAnimesAsync(animes);
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
