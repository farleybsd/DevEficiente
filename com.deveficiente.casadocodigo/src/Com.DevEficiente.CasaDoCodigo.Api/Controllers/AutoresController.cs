using Com.DevEficiente.CasaDoCodigo.Aplication.Commands;
using Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions;
using Com.DevEficiente.CasaDoCodigo.Aplication.Request;
using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using Com.DevEficiente.CasaDoCodigo.Domain.Entidades;
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
        public async Task<ActionResult<AutorResponse>> BuscarAutores([FromQuery] AutorByIdRequest autorRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(autorRequest.Id))
                    return BadRequest();

                var queryProduct = await _mediator.Send(autorRequest.RequestToCommand(autorRequest));
                return Ok(queryProduct);
            }
            catch (AutorByIdQueryException ex)
            {

                throw new Exception($"Autor não Encontrado: {ex.Message}");
            }

        }

        [HttpDelete("/delete-autor-pelo-id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAutorPeloId([FromQuery] AutorDeleteRequest autorDeleteRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var commandDelete = await _mediator.Send(autorDeleteRequest.RequestToCommand(autorDeleteRequest));
                return Ok(commandDelete);
            }
            catch (AutorDeletePeloIdException ex)
            {

                throw new Exception($"Erro Ao Deletar: {ex.Message}"); ;
            }
        }
    }
}