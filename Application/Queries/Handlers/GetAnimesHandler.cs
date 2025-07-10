using AutoMapper;
using MediatR;
using Application.DTOs;
using Application.Queries;
using Domain.Interfaces.Services;

namespace Application.Queries.Handlers;

public class GetAnimesHandler : IRequestHandler<GetAnimesQuery, IEnumerable<AnimeDTO>>
{
    private readonly IAnimeService _animeService;
    private readonly IMapper _mapper;

    public GetAnimesHandler(IAnimeService animeService, IMapper mapper)
    {
        _animeService = animeService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnimeDTO>> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
    {
        var animes = await _animeService.GetAnimes(request.filter);
        var animesDTO = _mapper.Map<IEnumerable<AnimeDTO>>(animes);
        return animesDTO;
    }
}