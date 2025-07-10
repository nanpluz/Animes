using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries;

namespace API.Controllers
{
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
        [Route("animes")]
        public async Task<IActionResult> GetAnimes([FromQuery] AnimesFilter filter)
        {
            try
            {
                _logger.LogInformation("GetAnimes called");

                var animes = await _mediator.Send(new GetAnimesQuery(filter));
                return Ok(animes);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Error while getting animes");            
                
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting animes");

                return StatusCode(500);
            }
        }
    }
}
