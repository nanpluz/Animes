using AutoMapper;
using MediatR;
using Application.DTOs;
using Domain.Entities;
using Application.Interfaces.Services;

namespace Application.Queries.Handlers;

public class GetAnimesHandler : IRequestHandler<GetAnimesQuery, IEnumerable<GetAnimesResponse>>
{
    private readonly IAnimeService _animeService;
    private readonly IMapper _mapper;

    public GetAnimesHandler(IAnimeService animeService, IMapper mapper)
    {
        _animeService = animeService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAnimesResponse>> Handle(GetAnimesQuery query, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<Anime>(query.request);
        var animes = await _animeService.GetAnimes(filter);
        return _mapper.Map<IEnumerable<GetAnimesResponse>>(animes);
    }
}