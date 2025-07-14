using MediatR;
using AutoMapper;
using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Commands.Handlers
{
    public class CreateAnimeHandler : IRequestHandler<CreateAnimeCommand>
    {
        private readonly IAnimeService _animeService;
        private readonly IMapper _mapper;

        public CreateAnimeHandler(IAnimeService animeService, IMapper mapper)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        public async Task Handle(CreateAnimeCommand command, CancellationToken cancellationToken)
        {
            await _animeService.CreateAnime(_mapper.Map<Anime>(command.request));
        }
    }
}
