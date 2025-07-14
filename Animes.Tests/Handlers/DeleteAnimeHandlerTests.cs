using Application.Commands;
using Application.Commands.Handlers;
using Domain.Entities;
using Infrastructure.Services;

public class DeleteAnimeHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_ShouldDeleteAnime()
    {
        // Arrange
        var anime = new Anime { Name = "Naruto" };
        _dbContext.Animes.Add(anime);
        await _dbContext.SaveChangesAsync();

        var handler = new DeleteAnimeHandler(new AnimeService(new AnimeRepository(_dbContext)));
        var command = new DeleteAnimeCommand(anime.Id);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        var deleted = _dbContext.Animes.Find(anime.Id);
        Assert.Null(deleted);
    }
}