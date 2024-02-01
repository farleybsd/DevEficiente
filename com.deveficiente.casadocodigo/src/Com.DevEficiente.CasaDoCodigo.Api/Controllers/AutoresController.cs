using Com.DevEficiente.CasaDoCodigo.Aplication.Request;
using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ILogger<AutoresController> _logger;
        private readonly IMediator _mediator;
        public AutoresController(ILogger<AutoresController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/Criar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] AutorRequest autorRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var autorSaveCommand = autorRequest.toCommand(autorRequest);
            var command = await _mediator.Send(autorSaveCommand);
            return Ok(command);
        }
    }
}