using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetAnimesQuery(GetAnimesRequest request) : IRequest<IEnumerable<GetAnimesResponse>>
    {
        public GetAnimesRequest request { get; set; } = request;
    }
}