using MediatR;
using Application.Interfaces.Services;

namespace Application.Commands.Handlers
{
    public class DeleteAnimeHandler : IRequestHandler<DeleteAnimeCommand>
    {
        private readonly IAnimeService _animeService;

        public DeleteAnimeHandler(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        public async Task Handle(DeleteAnimeCommand command, CancellationToken cancellationToken)
        {
            await _animeService.DeleteAnime(command.Id);
        }
    }
}
