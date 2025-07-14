using MediatR;
using AutoMapper;
using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Commands.Handlers
{
    public class UpdateAnimeHandler : IRequestHandler<UpdateAnimeCommand>
    {
        private readonly IAnimeService _animeService;
        private readonly IMapper _mapper;

        public UpdateAnimeHandler(IAnimeService animeService, IMapper mapper)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAnimeCommand command, CancellationToken cancellationToken)
        {
            await _animeService.UpdateAnime(_mapper.Map<Anime>(command.request));
        }
    }
}
