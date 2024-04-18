using Com.DevEficiente.CasaDoCodigo.Aplication.Mappers;
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
        public async Task<IActionResult> CriarPais([FromBody] PaisRequest paisRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var paisSaveCommand = paisRequest.RequestToCommand(paisRequest);
                var command = await _mediator.Send(paisSaveCommand);
                return Ok(command);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Erro ao Salvar Um País: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Pais  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Pais");
            }
            
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
