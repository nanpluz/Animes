using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class CreateAnimeCommand(CreateAnimeRequest request) : IRequest
    {
        public CreateAnimeRequest request = request;
    }
}
