using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class UpdateAnimeCommand(UpdateAnimeRequest request) : IRequest
    {
        public UpdateAnimeRequest request = request;
    }
}
