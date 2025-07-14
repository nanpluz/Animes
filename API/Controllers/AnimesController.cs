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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAnimesResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeRequest request)
        {
            try
            {
                _logger.LogInformation("CreateAnime called");

                await _mediator.Send(new CreateAnimeCommand(request));

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while creating animes");
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAnime([FromBody] UpdateAnimeRequest request)
        {
            try
            {
                _logger.LogInformation("Update anime called");

                await _mediator.Send(new UpdateAnimeCommand(request));

                return NoContent();
            } 
            catch (KeyNotFoundException ex)
            {
                _logger.LogError("Did not find key while trying to update an anime");
                return NotFound(new { message = ex.Message });
            } 
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while trying to update an anime");
                return StatusCode(500);
            }
        }
    }
}
