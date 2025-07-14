using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries;
using Application.DTOs;
using Application.Commands;
using Asp.Versioning;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AnimesController : ControllerBase
    {
        private readonly ILogger<AnimesController> _logger;
        private readonly IMediator _mediator;

        public AnimesController(
            ILogger<AnimesController> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAnimes([FromQuery] GetAnimesRequest request)
        {
            try
            {
                _logger.LogInformation("GetAnimes called");

                var animes = await _mediator.Send(new GetAnimesQuery(request));
                return Ok(animes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting animes");

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimes([FromBody] IEnumerable<CreateAnimesRequest> createAnimeRequest)
        {
            var animes = await _mediator.Send(new CreateAnimesCommand(createAnimeRequest));

            if (animes.created == false)
            {
                _logger.LogWarning("Error while creating anime");
                return BadRequest("Error while creating anime");
            }
            else
            {
                _logger.LogInformation("Anime created successfully");
                return Created();
            }
        } 
    }
}
