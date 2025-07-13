using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class CreateAnimesCommand(IEnumerable<CreateAnimeRequest> createAnimeRequest) : IRequest<CreateAnimeResponse>
    {
        public IEnumerable<CreateAnimeRequest> createAnimeRequest = createAnimeRequest;
    }
}
