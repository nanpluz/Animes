using Application.DTOs;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Queries
{
    public class GetAnimesQuery(AnimesFilter filter) : IRequest<IEnumerable<AnimeDTO>>
    {
        public AnimesFilter filter { get; set; } = filter;
    }
}