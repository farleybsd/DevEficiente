using Com.DevEficiente.CasaDoCodigo.Aplication.Mappers;

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
        public async Task<IActionResult> CriarLivro([FromBody] PaisRequest paisRequest)
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
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar Um Livro  - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar Um Livro");
            }
        }

    }
}
