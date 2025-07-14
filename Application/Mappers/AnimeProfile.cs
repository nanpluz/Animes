using Application.DTOs;
using Application.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<GetAnimesQuery, Anime>();
        CreateMap<Anime, GetAnimesResponse>();

        CreateMap<CreateAnimeRequest, Anime>();
    }
}
