using MediatR;
using AutoMapper;
using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Commands.Handlers
{
    public class CreateAnimesHandler : IRequestHandler<CreateAnimesCommand, CreateAnimeResponse>
    {
        private readonly IAnimeService _animeService;
        private readonly IMapper _mapper;

        public CreateAnimesHandler(IAnimeService animeService, IMapper mapper)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        public async Task<CreateAnimeResponse> Handle(CreateAnimesCommand command, CancellationToken cancellationToken)
        {
            var animes = _mapper.Map<IEnumerable<Anime>>(command.createAnimeRequest);
            var createdAnimes = await _animeService.CreateAnimes(animes);
            var createAnimeResponse = new CreateAnimeResponse();
            createAnimeResponse.created = createdAnimes;
            return createAnimeResponse;
        }
    }
}
