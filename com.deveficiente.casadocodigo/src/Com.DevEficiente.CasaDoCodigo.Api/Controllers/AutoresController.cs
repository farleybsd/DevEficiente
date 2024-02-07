namespace Com.DevEficiente.CasaDoCodigo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AutoresController> _logger;

        public AutoresController(IMediator mediator,
                                 ILogger<AutoresController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("/Criar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Criar([FromBody] AutorRequest autorRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var autorSaveCommand = autorRequest.RequestToCommand(autorRequest);
                var command = await _mediator.Send(autorSaveCommand);
                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Salvar o Autor - {ex.Message}");
                throw new Exception("Erro inesperado ao Salvar o Autor");
            }
        }

        [HttpGet("/Buscar-autores")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AutorResponse>> BuscarAutores([FromQuery] AutorByIdRequest autorRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(autorRequest.Id))
                    return BadRequest();

                var queryAutor = await _mediator.Send(autorRequest.RequestToCommand(autorRequest));
                return Ok(queryAutor);
            }
            catch (AutorByIdQueryException ex)
            {
                _logger.LogError($"Erro Ao Buscar Autor: {ex.Message}");
                throw new Exception("Erro Ao Buscar Autor:");
            }
        }

        [HttpDelete("/Delete-autor-pelo-id")]
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
                _logger.LogError($"Erro Ao Deletar: {ex.Message}");
                throw new Exception("Erro Ao Deletar:"); ;
            }
        }

        [HttpGet("Buscar-todos-autores")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<AutorResponse>>> BuscarTodosAutores()
        {
            try
            {
                var queryAutores = await _mediator.Send(new BuscarTodosAutoresCommand());
                return Ok(queryAutores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado ao Buscar os Autores - {ex.Message}");
                throw new Exception("Erro inesperado ao Buscar os Autores"); ;
            }
        }

        [HttpPut("Editar-autor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorEditarRequest))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AutorResponse>> EditarAutor(AutorEditarRequest autorEditarRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var commandEditar = await _mediator.Send(autorEditarRequest.RequestToCommand(autorEditarRequest));

                return Ok(commandEditar);
            }
            catch (AutorEditarDadosException ex)
            {
                _logger.LogError($"Erro inesperado ao Editar os Autores - {ex.Message}");
                throw new Exception($"Erro inesperado ao Editar os Autores"); ;
            }
        }
    }
}