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
    public async Task<IEnumerable<Anime>> GetAnimes(Anime filter)
    {
        return await _animeRepository.GetAnimesAsync(filter);
    }
    public async Task CreateAnime(Anime anime)
    {
        await _animeRepository.CreateAnimeAsync(anime);
    }
    public async Task UpdateAnime(Anime anime)
    {
        await _animeRepository.UpdateAnimeAsync(anime);
    }
    public async Task DeleteAnime(int Id)
    {
        await _animeRepository.DeleteAnimeAsync(Id);
    }
}
