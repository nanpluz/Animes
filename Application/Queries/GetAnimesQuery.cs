using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetAnimesQuery(GetAnimesRequest getAnimesRequest) : IRequest<IEnumerable<GetAnimesResponse>>
    {
        public GetAnimesRequest getAnimesRequest { get; set; } = getAnimesRequest;
    }
}