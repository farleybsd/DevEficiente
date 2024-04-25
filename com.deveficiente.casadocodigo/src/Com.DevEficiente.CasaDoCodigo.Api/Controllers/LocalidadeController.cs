using Com.DevEficiente.CasaDoCodigo.Domain.ResultObjects;
using System.ComponentModel.DataAnnotations;

namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalidadeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LocalidadeController> _logger;

        public LocalidadeController(IMediator mediator,
                                    ILogger<LocalidadeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/CriarPais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaisResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Result<PaisResponse>> CriarPais([FromBody] PaisRequest paisRequest)
        {
            if (!ModelState.IsValid)
            {
                return new Result<PaisResponse>
                {
                    Succeeded = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                };
            }
            var paisSaveCommand = paisRequest.RequestToCommand(paisRequest);
            var command = await _mediator.Send(paisSaveCommand);

            return new Result<PaisResponse>
            {
                Succeeded = true,
                Data = command.Data
            };
        }

        [HttpPost("/CriarEstado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstadoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarEstado([FromBody] EstadoRequest estadoRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var paisSaveCommand = estadoRequest.RequestToCommand(estadoRequest);
                var command = await _mediator.Send(paisSaveCommand);
                return Ok(command);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Erro ao Salvar Um Estado: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Estado  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Estado");
            }
        }
    }
}