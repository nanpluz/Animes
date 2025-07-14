using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<GetAnimesRequest, Anime>();
        CreateMap<Anime, GetAnimesResponse>();

        CreateMap<CreateAnimesRequest, Anime>();
    }
}
