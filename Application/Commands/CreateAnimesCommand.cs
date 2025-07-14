using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class CreateAnimesCommand(IEnumerable<CreateAnimesRequest> createAnimeRequest) : IRequest<CreateAnimesResponse>
    {
        public IEnumerable<CreateAnimesRequest> createAnimeRequest = createAnimeRequest;
    }
}
