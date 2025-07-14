using Application.Commands;
using Application.Commands.Handlers;
using Application.DTOs;
using Infrastructure.Services;
using AutoMapper;

public class CreateAnimeHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_ShouldAddAnime()
    {
        // Arrange
        var handler = new CreateAnimeHandler(new AnimeService(new AnimeRepository(_dbContext)), _mapper);
        var request = new CreateAnimeRequest
        {
            Name = "One Piece",
            Director = "Oda",
            Summary = "Pirate king"
        };
        var command = new CreateAnimeCommand(request);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        var created = _dbContext.Animes.FirstOrDefault();
        Assert.NotNull(created);
        Assert.Equal("One Piece", created.Name);
    }
}