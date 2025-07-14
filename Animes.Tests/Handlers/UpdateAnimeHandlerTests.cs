using Application.Commands;
using Application.Commands.Handlers;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Services;

public class UpdateAnimeHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_ShouldUpdateAnime()
    {
        // Arrange
        var anime = new Anime { Name = "nomi", Director = "diretoh dunomi" };
        _dbContext.Animes.Add(anime);
        await _dbContext.SaveChangesAsync();

        var handler = new UpdateAnimeHandler(new AnimeService(new AnimeRepository(_dbContext)), _mapper);
        var request = new UpdateAnimeRequest
        {
            Id = anime.Id,
            Name = "novonomi",
            Director = "novodiretoh dunomi"
        };
        var command = new UpdateAnimeCommand(request);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        var updated = _dbContext.Animes.Find(anime.Id);
        Assert.Equal("novonomi", updated.Name);
        Assert.Equal("novodiretoh dunomi", updated.Director);
    }
}