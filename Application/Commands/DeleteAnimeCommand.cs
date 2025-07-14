using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class DeleteAnimeCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
