using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetAnimesQuery(GetAnimesRequest request) : IRequest<IEnumerable<GetAnimesResponse>>
    {
        public int Id = request.Id;
        public string Name = request.Name;
        public string Director = request.Director;
        public string Summary = request.Summary;
    }
}