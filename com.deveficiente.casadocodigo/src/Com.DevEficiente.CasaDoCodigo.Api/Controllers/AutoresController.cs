using Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions;
using Com.DevEficiente.CasaDoCodigo.Aplication.Queries;
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

        [HttpGet("/buscar-autores")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AutorResponse>> BuscarAutores([FromQuery] AutorByIdQuery autorId)
        {
            try
            {
                if (string.IsNullOrEmpty(autorId.Id))
                    return BadRequest();

                var queryProduct = await _mediator.Send(autorId);
                return Ok(queryProduct);
            }
            catch (AutorByIdQueryException ex)
            {

                throw new Exception($"Autor não Encontrado: {ex.Message}");
            }

        }
    }
}